using MediatR;
using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Application.Projects.Commands.Update
{
    public class UpdateProjectCommand : IRequest
    {
        public int ProjectId {get; set;}
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public int? FunderId { get; set; }
        public decimal Amount { get; set; }
    }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IRepository<Project> _repository;

        public UpdateProjectCommandHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ProjectId, cancellationToken);
            if(entity is null)
                throw new NotFoundException(nameof(Project), request.ProjectId, 422);

            entity.ProjectId = request.ProjectId;
            entity.Amount = request.Amount;
            entity.DepartmentId = request.DepartmentId;
            entity.FunderId = request.FunderId;
            entity.Name = request.Name;
            await _repository.AddAsync(entity, cancellationToken);
        }
    }
}