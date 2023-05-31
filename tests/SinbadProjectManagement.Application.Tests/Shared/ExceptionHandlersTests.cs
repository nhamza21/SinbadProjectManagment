using Castle.Core.Logging;
using FluentValidation.Internal;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Application.Shared.Exceptions.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SinbadProjectManagement.Application.Tests.Shared
{
    public class ExceptionHandlersTests
    {
        [Fact]
        public void BadRequestExceptionHandler_HandleException_ShouldReturnCorrectErrorMessage()
        {
            //Arrange
            var exception = new BadRequestException("BadRequest");
            var mockLogger = new Mock<ILogger<BadRequestExceptionHandler>>();

            var logger = mockLogger.Object;

            var handler = new BadRequestExceptionHandler(logger);

            //Action 

            var result = handler.HandleException(exception);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("BadRequest", result.Message);
        }

        [Fact]
        public void DeleteFailureExceptionHandler_HandleException_ShouldReturnCorrectErrorMessage()
        {
            //Arrange
            var exception = new DeleteFailureException("Project", 1, "");
            var mockLogger = new Mock<ILogger<DeleteFailureExceptionHandler>>();

            var logger = mockLogger.Object;

            var handler = new DeleteFailureExceptionHandler(logger);

            //Action 

            var result = handler.HandleException(exception);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(409, result.StatusCode);
            Assert.Equal("Deletion of entity \"Project\" (1) failed. ", result.Message);
        }

        [Fact]
        public void NotFoundExceptionHandler_HandleException_ShouldReturnCorrectErrorMessage()
        {
            //Arrange
            var exception = new NotFoundException("Project", 1, 404);
            var mockLogger = new Mock<ILogger<NotFoundExceptionHandler>>();

            var logger = mockLogger.Object;

            var handler = new NotFoundExceptionHandler(logger);

            //Action 

            var result = handler.HandleException(exception);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Entity \"Project\" (1) was not found.", result.Message);
        }

        [Fact]
        public void ValidationExceptionHandler_HandleException_ShouldReturnCorrectErrorMessage()
        {
            //Arrange
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Amount", "Project Amount must be greater than 0")
            };
            var assertionResult = "One or more validation failures have occurred.\r\n{\"Amount\":[\"Project Amount must be greater than 0\"]}";

            var exception = new SinbadValidationException(failures);
            var mockLogger = new Mock<ILogger<ValidationExceptionHandler>>();

            var logger = mockLogger.Object;

            var handler = new ValidationExceptionHandler(logger);

            //Action 

            var result = handler.HandleException(exception);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.NotEmpty(result.Message);
            Assert.StartsWith("One or more validation failures have occurred.", result.Message);
            Assert.Equal(assertionResult, result.Message);
        }
    }
}
