using bookreview.common.Models;
using bookreview.controller.Controllers;
using bookreview.service.Services.Interfaces;
using Moq;

namespace attomic.chicken.test.controllers
{
    [TestClass]
    public class PublisherControllerTests
    {
        private Mock<IPublisherService>? _publisherServiceMock;
        private PublisherController? _publisherController;

        [TestInitialize]
        public void Setup()
        {
            _publisherServiceMock = new Mock<IPublisherService>();
            _publisherController = new PublisherController(_publisherServiceMock.Object);
        }

        [TestMethod]
        public async Task AddNewPublisher_WithValidPublisher_ReturnsAddedPublisher()
        {
            // Arrange
            var publisherToAdd = new PublisherModel { Name = "New Publisher" };
            var expectedPublisher = new PublisherModel { Id = 1, Name = "New Publisher" };

            _publisherServiceMock.Setup(service => service.AddNewPublisher(publisherToAdd)).ReturnsAsync(expectedPublisher);

            // Act
            var result = await _publisherController.AddNewPublisher(publisherToAdd);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<PublisherModel>(result);
            Assert.AreEqual(expectedPublisher.Id, result.Id);
            Assert.AreEqual(expectedPublisher.Name, result.Name);
        }

        [TestMethod]
        public async Task UpdatePublisher_WithValidPublisher_ReturnsUpdatedPublisher()
        {
            // Arrange
            var publisherToUpdate = new PublisherModel { Id = 1, Name = "Updated Publisher" };
            var expectedPublisher = new PublisherModel { Id = 1, Name = "Updated Publisher" };

            _publisherServiceMock.Setup(service => service.UpdatePublisher(publisherToUpdate)).ReturnsAsync(expectedPublisher);

            // Act
            var result = await _publisherController.UpdatePublisher(publisherToUpdate);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<PublisherModel>(result);
            Assert.AreEqual(expectedPublisher.Id, result.Id);
            Assert.AreEqual(expectedPublisher.Name, result.Name);
        }

        [TestMethod]
        public async Task GetPublisher_WithValidId_ReturnsPublisher()
        {
            // Arrange
            int publisherId = 1;
            var expectedPublisher = new PublisherModel { Id = publisherId, Name = "Publisher 1" };

            _publisherServiceMock.Setup(service => service.GetPublisher(publisherId)).ReturnsAsync(expectedPublisher);

            // Act
            var result = await _publisherController.GetPublisher(publisherId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<PublisherModel>(result);
            Assert.AreEqual(expectedPublisher.Id, result.Id);
            Assert.AreEqual(expectedPublisher.Name, result.Name);
        }
    }
}
