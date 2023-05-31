using Microsoft.Extensions.DependencyInjection;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;
using SinbadProjectManagement.Infrastructure.Persistance.Repositories;

namespace SinbadProjectManagement.Infrastructure.Persistance
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructurePersistance(this IServiceCollection services)
        {
            services.AddDbContext<SinbadDbContext>();
            services.AddScoped<ISinbadDbContext>(provider => provider.GetService<SinbadDbContext>());
        
            // Register repositories
            services.AddScoped<IRepository<Department>, DepartmentRepository>();
            services.AddScoped<IRepository<Funder>, FunderRepository>();
            services.AddScoped<IRepository<Project>, ProjectRepository>();
            services.AddScoped<IRepository<Contract>, ContractRepository>();
            services.AddScoped<IRepository<Beneficiary>, BeneficiaryRepository>();
        }
    }
}