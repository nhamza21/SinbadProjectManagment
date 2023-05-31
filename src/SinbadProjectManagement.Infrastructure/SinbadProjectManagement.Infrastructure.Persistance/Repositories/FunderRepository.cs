using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Infrastructure.Persistance.Repositories
{
    public class FunderRepository : IRepository<Funder>
    {
        private readonly ISinbadDbContext _dbContext;

        public FunderRepository(ISinbadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> AddAsync(Funder entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task AddManyAsync(IEnumerable<Funder> entities, CancellationToken cancellationToken)
        {
            _dbContext.Funders.AddRange(entities);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAsync(Funder entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Funder>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Funder> GetByIdAsync(int id,CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        
        public bool HasElement(Expression<Func<Funder, bool>>  predicateExpression)
        {
            return _dbContext.Funders.Any(predicateExpression);
        }

        public Task UpdateAsync(Funder entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}