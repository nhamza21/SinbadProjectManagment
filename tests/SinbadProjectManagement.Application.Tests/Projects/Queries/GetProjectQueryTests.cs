using AutoMapper;
using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Application.Projects.Commands.Delete;
using SinbadProjectManagement.Application.Projects.Queries;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SinbadProjectManagement.Application.Tests.Projects.Queries
{
    public class GetProjectQueryTests : BaseProjectsQueriesTests
    {
        [Fact]
        public async void Handle_WhenQueryIsValid_SHouldReturnProjectDto()
        {
            //Arrange
            var query = new GetProjectQuery { Id = 3};
            var projectEntity = new Project
            {
                Amount = 3000,
                Code = "f54546565GG4df",
                DepartmentId = 3,
                FunderId = 3,
                Name = "Theory3",
                ProjectId = 3
            };

            _mockProjectRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>(), new CancellationToken()))
                .Returns(Task.FromResult(projectEntity));

            var repository = _mockProjectRepository.Object;

            var handler = new GetProjectsQueryHandler(repository,_mapper);

            //Action
            var result = await handler.Handle(query, new CancellationToken());

            //Assert
            Assert.NotNull(result);
            Assert.Equal(projectEntity.Name, result.Name);
            Assert.Equal(projectEntity.Code, result.Code);
            Assert.Equal(projectEntity.DepartmentId, result.DepartmentId);
            Assert.Equal(projectEntity.FunderId, result.FunderId);
            Assert.Equal(projectEntity.ProjectId, result.ProjectId);
            Assert.Equal(projectEntity.Amount, result.Amount);

        }

        [Fact]
        public async void Handle_WhenQueryIsNotValid_ShouldThrowNotFoundException()
        {
            //Arrange
            var query = new GetProjectQuery { Id = 3 };

            _mockProjectRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>(), new CancellationToken()))
                .Returns(Task.FromResult<Project>(null));
            
            var repository = _mockProjectRepository.Object;

            var handler = new GetProjectsQueryHandler(repository, _mapper);

            //Action
            //Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(query, new CancellationToken()));
            Assert.NotNull(exception);
            Assert.Equal($"Entity \"{nameof(Project)}\" (3) was not found.", exception.Message);
            Assert.Equal(404, exception.Code);
        }
    }
}
