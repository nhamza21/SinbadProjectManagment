using SinbadProjectManagement.Application.Projects.Commands.Delete;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Application.Tests.Projects
{
    public class BaseProjectTests
    {
        protected Mock<IRepository<Project>> _mockProjectRepository;
        public BaseProjectTests()
        {
            _mockProjectRepository = new Mock<IRepository<Project>>();
        }
    }

    public static class ScenarioHelper
    {
        public static T When<T>(this T @this)
        {
            return @this;
        }

        public static T Then<T>(this T @this)
        {
            return @this;
        }
    }

    public class FakeProjectRepository : IRepository<Project>
    {
        public Task<int> AddAsync(Project entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddManyAsync(IEnumerable<Project> entities, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Project entity, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if(id > 10)
                return Task.FromResult<Project>(null);
            return Task.FromResult(new Project());
        }

        public bool HasElement(Expression<Func<Project, bool>> predicateExpression)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Project entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeContractsRecpository : IRepository<Contract>
    {
        public TestInput Input {private get; set; }

        public FakeContractsRecpository()
        {
            Input = new TestInput();
        }

        public Task<int> AddAsync(Contract entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddManyAsync(IEnumerable<Contract> entities, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Contract entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contract>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Contract> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool HasElement(Expression<Func<Contract, bool>> predicateExpression)
        {
            return Input.HasElementBehavour;
        }

        public Task UpdateAsync(Contract entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public class TestInput
        {
            public Contract ContractProperty { get; set; }
            public bool HasElementBehavour { get; set; }
        }
    }
}
