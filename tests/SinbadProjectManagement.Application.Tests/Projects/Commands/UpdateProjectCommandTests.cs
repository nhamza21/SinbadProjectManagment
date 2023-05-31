using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Application.Projects.Commands.Create;
using SinbadProjectManagement.Application.Projects.Commands.Update;
using SinbadProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Application.Tests.Projects.Commands
{
    public class UpdateProjectCommandTests : BaseProjectTests
    {
        [Fact]
        public async void Handle_WhenUpdateCommandIsValid_ShouldReturnIdNotEqualToZero()
        {
            //Arrange
            var project = new Project();
            var command = new UpdateProjectCommand
            {
                ProjectId = 1,
                Amount = 1000,
                DepartmentId = 1,
                FunderId = 2,
                Name = "Test"
            };
            _mockProjectRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>(), new CancellationToken()))
                .Returns(Task.FromResult(project));

            var repository = _mockProjectRepository.Object;

            var handler = new UpdateProjectCommandHandler(repository);

            //Action
            await handler.Handle(command, new CancellationToken());

            //Assert

            Assert.NotNull(project);
            Assert.Equal(1, project.ProjectId);
            Assert.Equal(1000, project.Amount);
            Assert.Equal(1, project.DepartmentId);
            Assert.Equal(2, project.FunderId);
            Assert.Equal("Test", project.Name);
        }

        [Fact]
        public async void Handle_WhenEntityIsNotFound_ShouldThrowNotFoundException()
        {
            //Arrange
            var command = new UpdateProjectCommand();
            _mockProjectRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>(), new CancellationToken()))
                .Returns(Task.FromResult<Project>(null));
            
            var repository = _mockProjectRepository.Object;
            var handler = new UpdateProjectCommandHandler(repository);

            //Assert
            var ex = await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.NotNull(ex);
            Assert.Equal($"Entity \"{nameof(Project)}\" (0) was not found.", ex.Message);
            Assert.Equal(422, ex.Code);
        }
    }
}