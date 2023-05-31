using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Infrastructure.Persistance.Repositories
{
    public class ContractRepository : IRepository<Contract>
    {
        private readonly ISinbadDbContext _dbContext;

        public ContractRepository(ISinbadDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public Task<Contract> GetByIdAsync(int id,CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool HasElement(Expression<Func<Contract, bool>> predicateExpression)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Contract entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}