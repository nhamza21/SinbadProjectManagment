using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Application.Shared.Seed
{
    public class SeedCommand : IRequest
    {
        
    }

    public class SeedCommandHandler : IRequestHandler<SeedCommand>
    {

        private readonly IRepository<Project> _projectRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Funder> _funderRepository;

        public SeedCommandHandler(IRepository<Funder> funderRepository, IRepository<Department> departmentRepository, IRepository<Project> projectRepository)
        {
            _funderRepository = funderRepository;
            _departmentRepository = departmentRepository;
            _projectRepository = projectRepository;
        }

        public async Task Handle(SeedCommand request, CancellationToken cancellationToken)
        {
            if(_departmentRepository.HasElement(d => d.DepartmentId == 1))
                return;

            //prep data
            var funders = new Funder[] 
                {
                    new Funder {FunderId = 1, MoneyProvided=7000, Name="European Union"},
                    new Funder {FunderId = 2, MoneyProvided=5000, Name="GIZ"},
                    new Funder {FunderId = 3, MoneyProvided=5000, Name="Ministère d'europe des affaires étrangères"}
                };
            var departments = new Department[]
                {
                    new Department {DepartmentId = 1, Name="Gouvernance"},
                    new Department {DepartmentId = 2, Name="Droits humains"},
                    new Department {DepartmentId = 3, Name="Santé"}  
                };
            
            var projects = new Project[]
                {
                    new Project {ProjectId = 1, Amount = 3000, Code = "230527225625322", DepartmentId = 1, FunderId = 1, Name = "Progress", Funder = funders[0], Department = departments[0]},
                    new Project {ProjectId = 2, Amount = 4000, Code = "230527225625323", DepartmentId = 2, FunderId = 1, Name = "FGS", Funder=funders[0], Department = departments[1]},
                    new Project {ProjectId = 3, Amount = 5000, Code = "230527225625324", DepartmentId = 1, FunderId = 2, Name = "DATP", Funder=funders[1], Department=departments[0]}
                };



            Task[] tasks = new[] 
            {
                _funderRepository.AddManyAsync(funders, cancellationToken),
                _departmentRepository.AddManyAsync(departments, cancellationToken),
                _projectRepository.AddManyAsync(projects,cancellationToken)
            };
            await Task.WhenAll(tasks);           
        }
    }
}