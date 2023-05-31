using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Infrastructure.Persistance.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly ISinbadDbContext _dbContext;

        public DepartmentRepository(ISinbadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> AddAsync(Department entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task AddManyAsync(IEnumerable<Department> entities, CancellationToken cancellationToken)
        {
            _dbContext.Departments.AddRange(entities);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAsync(Department entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetByIdAsync(int id,CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool HasElement(Expression<Func<Department, bool>> predicateExpression = null)
        {
            return _dbContext.Departments.Any(predicateExpression);
        }

        public Task UpdateAsync(Department entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}