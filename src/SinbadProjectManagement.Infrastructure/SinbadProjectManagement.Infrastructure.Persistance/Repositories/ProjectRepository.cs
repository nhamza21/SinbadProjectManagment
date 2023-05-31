using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Infrastructure.Persistance.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly ISinbadDbContext _dbContext;

        public ProjectRepository(ISinbadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Project entity, CancellationToken cancellationToken)
        {
            _dbContext.Projects.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.ProjectId;
        }

        public async Task AddManyAsync(IEnumerable<Project> entities, CancellationToken cancellationToken)
        {
            _dbContext.Projects.AddRange(entities);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Project entity, CancellationToken cancellationToken)
        {
            _dbContext.Projects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Projects
                    .Include(p => p.Funder)
                    .Include(p => p.Department)
                    .OrderBy(p => p.Name)
                    .ToListAsync(cancellationToken);
        }

        public async Task<Project> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Projects.FindAsync(id);
        }

        public bool HasElement(Expression<Func<Project, bool>> predicateExpression)
        {
            return _dbContext.Projects.Any(predicateExpression);
        }

        public async Task UpdateAsync(Project entity, CancellationToken cancellationToken)
        {
            _dbContext.Projects.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}