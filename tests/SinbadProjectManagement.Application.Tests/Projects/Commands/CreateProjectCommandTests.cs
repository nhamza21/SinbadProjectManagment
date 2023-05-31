using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Application.Projects.Commands.Create;
using SinbadProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Application.Tests.Projects.Commands
{
    public class CreateProjectCommandTests : BaseProjectTests
    {
        [Fact]
        public async void Handle_WhenCommandIsValid_ShouldReturnProjectCode()
        {
            //Arrange
            var command = new CreateProjectCommand
            {
                Amount = 1000,
                DepartmentId = 1,
                FunderId = 2,
                Name = "Test"
            };
            _mockProjectRepository
                .Setup(x=>x.AddAsync(It.IsAny<Project>(), new CancellationToken()))
                .Returns(Task.FromResult(2));

            var repository = _mockProjectRepository.Object;

            var handler = new CreateProjectCommandHandler(repository);

            //Action
            var result = await handler.Handle(command, new CancellationToken());

            //Assert

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(15, result.Length);
        }
    }
}