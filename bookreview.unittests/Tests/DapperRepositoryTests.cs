using bookreview.infrastructure.Repository;
using bookreview.common;
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using bookreview.infrastructure.Repository.EFCore;
using bookreview.infrastructure.DataModel;

namespace bookreview.unittests
{
    public class DapperRepositoryTests
    {
        private readonly Mock<IOptions<ConnectionStringSettings>> _mockConnectionStringSettings;
        private readonly Mock<DatabaseContext> _mockContext;
        private readonly Mock<ILogger<DapperRepository>> _mockLogger;
        private readonly DapperRepository _repository;

        public DapperRepositoryTests()
        {
            _mockConnectionStringSettings = new Mock<IOptions<ConnectionStringSettings>>();
            _mockContext = new Mock<DatabaseContext>(new DbContextOptions<DatabaseContext>());
            _mockLogger = new Mock<ILogger<DapperRepository>>();

            _mockConnectionStringSettings.Setup(x => x.Value).Returns(new ConnectionStringSettings { ConnectionString = "TestConnectionString" });

            _repository = new DapperRepository(_mockConnectionStringSettings.Object, _mockContext.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task ExecuteQueryAsync_ShouldReturnExpectedResults()
        {
            // Arrange
            var queryString = "SELECT * FROM Authors";
            var parameters = new DynamicParameters();
            var expectedResults = new List<Author> { new Author { AuthorId = 1, Forename = "John", Surname = "Doe" } };

            var mockDbConnection = new Mock<IDbConnection>();
            _mockContext.Setup(c => c.Database.GetDbConnection()).Returns(mockDbConnection.Object);
            mockDbConnection.Setup(c => c.QueryAsync<Author>(queryString, parameters)).ReturnsAsync(expectedResults);

            // Act
            var result = await _repository.ExecuteQueryAsync<Author>(queryString, parameters);

            // Assert
            Assert.Equal(expectedResults, result);
        }

        [Fact]
        public async Task ExecuteQueryStringSingleAsync_ShouldReturnExpectedResult()
        {
            // Arrange
            var queryString = "SELECT * FROM Authors WHERE AuthorId = @AuthorId";
            var parameters = new DynamicParameters();
            parameters.Add("AuthorId", 1);
            var expectedResult = new Author { AuthorId = 1, Forename = "John", Surname = "Doe" };

            var mockDbConnection = new Mock<IDbConnection>();
            _mockContext.Setup(c => c.Database.GetDbConnection()).Returns(mockDbConnection.Object);
            mockDbConnection.Setup(c => c.QueryFirstOrDefaultAsync<Author>(queryString, parameters)).ReturnsAsync(expectedResult);

            // Act
            var result = await _repository.ExecuteQueryStringSingleAsync<Author>(queryString, parameters);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task ExecuteQueryWithMultipleReturns_ShouldThrowNotImplementedException()
        {
            // Arrange
            var queryString = "SELECT * FROM Authors; SELECT * FROM Books";
            var parameters = new DynamicParameters();

            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(async () => await _repository.ExecuteQueryWithMultipleReturns(queryString, parameters));
        }
    }
}
