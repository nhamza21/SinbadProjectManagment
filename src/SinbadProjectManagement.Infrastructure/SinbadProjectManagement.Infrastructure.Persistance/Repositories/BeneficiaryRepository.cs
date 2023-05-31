using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Infrastructure.Persistance.Repositories
{
    public class BeneficiaryRepository : IRepository<Beneficiary>
    {
        public Task<int> AddAsync(Beneficiary entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Beneficiary entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Beneficiary> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        
        public Task UpdateAsync(Beneficiary entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Beneficiary>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddManyAsync(IEnumerable<Beneficiary> entities, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool HasElement(Expression<Func<Beneficiary, bool>> predicateExpression)
        {
            throw new NotImplementedException();
        }
    }
}