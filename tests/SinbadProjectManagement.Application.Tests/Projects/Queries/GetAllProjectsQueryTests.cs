using AutoMapper;
using SinbadProjectManagement.Application.Projects.Queries;
using SinbadProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Application.Tests.Projects.Queries
{
    public class GetAllProjectsQueryTests : BaseProjectsQueriesTests
    {
        public static IEnumerable<object[]> Projects
        {
            get
            {
                yield return new Project[] { new Project
                {
                    Amount = 1000,
                    Code = "f54545s4df",
                    DepartmentId = 1,
                    FunderId = 1,
                    Name = "Theory1",
                    ProjectId = 1
                } };
                yield return new Project[] { new Project
                {
                    Amount = 2000,
                    Code = "f54545HHHdf",
                    DepartmentId = 2,
                    FunderId = 2,
                    Name = "Theory2",
                    ProjectId = 2
                } };
                yield return new Project[] { new Project
                {
                    Amount = 3000,
                    Code = "f54546565GG4df",
                    DepartmentId = 3,
                    FunderId = 3,
                    Name = "Theory3",
                    ProjectId = 3
                } };
            }
        }

        [Theory]
        [MemberData(nameof(Projects))]
        public async void Handle_WhenCalled_ShouldReturnCorrectProjectListDto(Project project)
        {
            IEnumerable<Project> projects = new List<Project> { project };
            //Arrange
            _mockProjectRepository
                .Setup(x => x.GetAllAsync(new CancellationToken()))
                .Returns(Task.FromResult(projects));

            var repository = _mockProjectRepository.Object;            

            var handler = new GetAllProjectsQueryHandler(repository, _mapper);

            //Action
            var result = await handler.Handle(new GetAllProjectsQuery(), new CancellationToken());
            var element = result?.ProjectDtos?.FirstOrDefault();

            //Assert
            Assert.NotNull(result);            
            Assert.Single(result.ProjectDtos);
            Assert.NotNull(element);
            Assert.Equal(element.Name, project?.Name);
            Assert.Equal(element.Amount, project?.Amount);
            Assert.Equal(element.Code, project?.Code);
            Assert.Equal(element.DepartmentId, project?.DepartmentId);
            Assert.Equal(element.FunderId, project?.FunderId);            
        }
    }
}
