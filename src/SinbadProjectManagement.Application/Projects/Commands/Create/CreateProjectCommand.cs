using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Application.Projects.Commands.Create
{
    public class CreateProjectCommand : IRequest<string>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public int? FunderId { get; set; }
        public decimal Amount { get; set; }
    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, string>
    {
        private readonly IRepository<Project> _projectRepository;

        public CreateProjectCommandHandler(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<string> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = new Project()
            {
                Code = BuildProductCode(),
                Name = request.Name,
                Amount = request.Amount,
                FunderId = request.FunderId,
                DepartmentId = request.DepartmentId               
            };

            await _projectRepository.AddAsync(entity,cancellationToken);

            return entity.Code;
        }

        private string BuildProductCode()
        {
            return DateTime.Now.ToString("yyMMddHHmmssfff");
        }
    }
}