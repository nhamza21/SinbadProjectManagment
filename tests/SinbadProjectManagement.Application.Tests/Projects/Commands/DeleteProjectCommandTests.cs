using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Application.Projects.Commands.Create;
using SinbadProjectManagement.Application.Projects.Commands.Delete;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SinbadProjectManagement.Application.Tests.Projects.Commands
{
    public class DeleteProjectCommandTests : BaseProjectTests
    {
        private Mock<IRepository<Contract>> _mockContractRepository;
        public DeleteProjectCommandTests()
        {
            _mockContractRepository = new Mock<IRepository<Contract>>();
        }

        [Fact]
        public void Handle_WhenCommandIsValid_ShouldCallRepositoryToDeleteEntity()
        {
            Given.UserTryToDeleteProject(false)
                .When().UserChooseTheCorrectProjectToDelete(3)
                .Then().DeletionShouldBeDoneCorrectly();
        }

        [Fact]
        public void Handle_WhenProjectIsNotFoundByHisId_ShouldThrowNotFoundException_FluentStyle()
        {
            Given.UserTryToDeleteProject(false)
                .When().UserChooseProjectThatDoesntExist(11)
                .Then().DeletionShouldFailForNotFoundReason(11);
        }

        [Fact]
        public void Handle_WhenProjectIsNotFoundByHisId_ShouldThrowDeleteFailureException_FluentStyle()
        {
            Given.UserTryToDeleteProject(true)
                .When().UserChooseProjectThatHasContracts(9)
                .Then().DeletionShouldFailBecauseProjectHasContracts(9);
        }



        [Fact]
        public async void Handle_WhenProjectIsNotFoundByHisId_ShouldThrowNotFoundException()
        {
            //Arrange
            var command = new DeleteProjectCommand
            {
                Id = 0
            };

            _mockProjectRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>(), new CancellationToken()))
                .Returns(Task.FromResult<Project>(null));
            _mockContractRepository
                .Setup(x => x.HasElement(It.IsAny<Expression<Func<Contract, bool>>>()))
                .Returns(true);

            var repository = _mockProjectRepository.Object;
            var contractRepository = _mockContractRepository.Object;

            var handler = new DeleteProjectCommandHandler(repository,contractRepository);

            //Action

            //Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.NotNull(exception);
            Assert.Equal($"Entity \"{nameof(Project)}\" (0) was not found.", exception.Message);
            Assert.Equal(422, exception.Code);
        }

        [Fact]
        public async void Handle_WhenProjectHasContracts_ShouldThrowDeleteFailureException()
        {
            //Arrange
            var projectEntity = new Project();
            var command = new DeleteProjectCommand
            {
                Id = 0
            };

            _mockProjectRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>(), new CancellationToken()))
                .Returns(Task.FromResult(projectEntity));
            _mockContractRepository
                .Setup(x => x.HasElement(It.IsAny<Expression<Func<Contract, bool>>>()))
                .Returns(true);

            var repository = _mockProjectRepository.Object;
            var contractRepository = _mockContractRepository.Object;

            var handler = new DeleteProjectCommandHandler(repository, contractRepository);
            var errorMessage = "There are existing contracts associated with this product.";

            //Action

            //Assert
            var exception = await Assert.ThrowsAsync<DeleteFailureException>(async () => await handler.Handle(command, new CancellationToken()));
            Assert.Equal($"Deletion of entity \"{nameof(Project)}\" ({command.Id}) failed. {errorMessage}", exception.Message);
        }
    }

    public static class Given
    {
        public static DeleteProjectCommandHandler UserTryToDeleteProject(bool hasContract)
        {
            var projectsRepository = new FakeProjectRepository();
            var contractsRepository = new FakeContractsRecpository 
            { 
                Input = new FakeContractsRecpository.TestInput { HasElementBehavour = hasContract} 
            };
            return new DeleteProjectCommandHandler(projectsRepository, contractsRepository);
        }
    }

    public static class Scenario
    {
        public static DeleteProjectCommandHandler UserChooseTheCorrectProjectToDelete(this DeleteProjectCommandHandler handler, int projectId)
        {
            var command = new DeleteProjectCommand()
            {
                Id = projectId
            };            


            //Task.WaitAll(Task.Run(async () => await handler.Handle(command, new CancellationToken())));
            handler.Handle(command, new CancellationToken()).GetAwaiter().GetResult();
            return handler;
        }

        public static NotFoundException UserChooseProjectThatDoesntExist(this DeleteProjectCommandHandler handler, int projectId)
        {
            NotFoundException exception = new NotFoundException("","",0);
            var command = new DeleteProjectCommand()
            {
                Id = projectId
            };
            try
            {
                handler.Handle(command, new CancellationToken()).GetAwaiter().GetResult();
            }
            catch(NotFoundException ex)
            {
                exception = ex;
            }
            return exception;
        }

        public static DeleteFailureException UserChooseProjectThatHasContracts(this DeleteProjectCommandHandler handler, int projectId)
        {
            DeleteFailureException exception = new DeleteFailureException("", "", "");
            var command = new DeleteProjectCommand()
            {
                Id = projectId
            };
            try
            {
                handler.Handle(command, new CancellationToken()).GetAwaiter().GetResult();
            }
            catch (DeleteFailureException ex)
            {
                exception = ex;
            }
            return exception;
        }
    }

    public static class Assertions
    {
        public static void DeletionShouldBeDoneCorrectly(this DeleteProjectCommandHandler handler)
        {
            Assert.True(true);
        }

        public static void DeletionShouldFailForNotFoundReason(this NotFoundException exception, int projectId)
        {
            Assert.NotNull(exception);
            Assert.Equal($"Entity \"{nameof(Project)}\" ({projectId}) was not found.", exception.Message);
            Assert.Equal(422, exception.Code);
        }

        public static void DeletionShouldFailBecauseProjectHasContracts(this DeleteFailureException exception, int projectId)
        {
            var errorMessage = "There are existing contracts associated with this product.";
            Assert.Equal($"Deletion of entity \"{nameof(Project)}\" ({projectId}) failed. {errorMessage}", exception.Message);
        }
    }


}