using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using atomic.chicken.common.Enum;
using atomic.chicken.common.Models;
using atomic.chicken.controller.Controllers;
using atomic.chicken.service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace atomic.chicken.unittests
{
    [TestClass]
    public class AuthorControllerTests
    {
        private Mock<IAuthorService> _serviceMock;
        private AuthorController _controller;

        [TestInitialize]
        public void Setup()
        {
            _serviceMock = new Mock<IAuthorService>();
            _controller = new AuthorController(_serviceMock.Object);
        }

        [TestMethod]
        public async Task GetAllAuthors_ReturnsListOfAuthors()
        {
            // Arrange
            var expectedAuthors = new List<AuthorModel>
            {
                new AuthorModel { Id = 1, Forename = "John", Surname = "Doe", AuthorType = AuthorType.Review, DateOfBirth = new DateTime(1980, 1, 1) },
                new AuthorModel { Id = 2, Forename = "Jane", Surname = "Smith", AuthorType = AuthorType.Book, DateOfBirth = new DateTime(1990, 2, 2) }
            };

            _serviceMock.Setup(x => x.GetAllAuthors()).ReturnsAsync(expectedAuthors);

            // Act
            var result = await _controller.GetAllAuthors();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<AuthorModel>));
            CollectionAssert.AreEqual(expectedAuthors, result.ToList());
        }

        [TestMethod]
        public async Task GetAuthor_WithValidId_ReturnsAuthor()
        {
            // Arrange
            int authorId = 1;
            var expectedAuthor = new AuthorModel { Id = authorId, Forename = "John", Surname = "Doe", AuthorType = AuthorType.Book, DateOfBirth = new DateTime(1980, 1, 1) };

            _serviceMock.Setup(x => x.GetAuthor(authorId)).ReturnsAsync(expectedAuthor);

            // Act
            var result = await _controller.GetAuthor(authorId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AuthorModel));
            Assert.AreEqual(expectedAuthor, (AuthorModel)result);
        }

        [TestMethod]
        public async Task AddNewAuthor_WithValidAuthor_ReturnsAddedAuthor()
        {
            // Arrange
            var authorToAdd = new AuthorModel { Forename = "John", Surname = "Doe", AuthorType = AuthorType.Book, DateOfBirth = new DateTime(1980, 1, 1) };
            var expectedAuthor = new AuthorModel { Id = 1, Forename = "John", Surname = "Doe", AuthorType = AuthorType.Review, DateOfBirth = new DateTime(1980, 1, 1) };

            _serviceMock.Setup(x => x.AddNewAuthor(authorToAdd)).ReturnsAsync(expectedAuthor);

            // Act
            var result = await _controller.AddNewAuthor(authorToAdd);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AuthorModel));
            Assert.AreEqual(expectedAuthor, (AuthorModel)result);
        }

        [TestMethod]
        public async Task UpdateAuthor_WithValidAuthor_ReturnsUpdatedAuthor()
        {
            // Arrange
            var authorToUpdate = new AuthorModel { Id = 1, Forename = "John", Surname = "Doe", AuthorType = AuthorType.Book, DateOfBirth = new DateTime(1980, 1, 1) };
            var expectedAuthor = new AuthorModel { Id = 1, Forename = "John", Surname = "Doe", AuthorType = AuthorType.Review, DateOfBirth = new DateTime(1980, 1, 1) };

            _serviceMock.Setup(x => x.UpdateAuthor(authorToUpdate)).ReturnsAsync(expectedAuthor);

            // Act
            var result = await _controller.UpdateAuthor(authorToUpdate);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AuthorModel));
            Assert.AreEqual(expectedAuthor, (AuthorModel)result);
        }

        [TestMethod]
        public void PatchAuthorProperty_WithValidModel_ReturnsOkResult()
        {
            // Arrange
            var patchModel = new PatchModel { PropertyName = "Forename", PropertyValue = "John" };

            // Act
            var result = _controller.PatchAuthorProperty(patchModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void PatchAuthorProperty_WithInvalidModel_ReturnsBadRequestResult()
        {
            // Arrange
            var patchModel = new PatchModel { PropertyName = "InvalidProperty", PropertyValue = "Value" };

            _serviceMock.Setup(service => service.PatchProperty(patchModel)).Throws(new Exception());
            // Act
            var result = _controller.PatchAuthorProperty(patchModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}
