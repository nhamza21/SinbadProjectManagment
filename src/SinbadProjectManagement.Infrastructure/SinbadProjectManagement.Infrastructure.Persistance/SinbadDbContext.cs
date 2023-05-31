using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Infrastructure.Persistance
{
    public class SinbadDbContext : DbContext, ISinbadDbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Funder> Funders { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
            .Property(p => p.ProjectId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Department>()
            .Property(p => p.DepartmentId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Funder>()
            .Property(p => p.FunderId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Projects)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Funder)
                .WithMany(l => l.Projects)
                .HasForeignKey(p => p.FunderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Project)
                .WithMany(p => p.Contracts)
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Beneficiary)
                .WithMany(t => t.Contracts)
                .HasForeignKey(c => c.BeneficiaryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.SeedData();
            base.OnModelCreating(modelBuilder);
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("SinbadDatabase");
        }
    }
}