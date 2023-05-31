using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Infrastructure.Persistance
{
    public interface ISinbadDbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Funder> Funders { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}