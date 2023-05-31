using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Infrastructure.Persistance
{
    public static class Seed
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {            
            builder.Entity<Department>().HasData(
                new Department {DepartmentId = 1, Name="Africa"},
                new Department {DepartmentId = 2, Name="South America"}                
            );

            builder.Entity<Funder>().HasData(
                new Funder {FunderId = 1, MoneyProvided=7000, Name="Jack Nicolson"},
                new Funder {FunderId = 2, MoneyProvided=5000, Name="Heth Ledger"}
            );

            builder.Entity<Project>().HasData(
                new Project {ProjectId = 1, Amount = 3000, Code = "230527225625322", DepartmentId = 1, FunderId = 1, Name = "alpha"},
                new Project {ProjectId = 2, Amount = 4000, Code = "230527225625323", DepartmentId = 2, FunderId = 1, Name = "beta"},
                new Project {ProjectId = 3, Amount = 5000, Code = "230527225625324", DepartmentId = 1, FunderId = 2, Name = "gamma"}
            );

            return builder;
        }
    }
}