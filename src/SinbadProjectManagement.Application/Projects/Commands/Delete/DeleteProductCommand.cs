using MediatR;
using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Application.Projects.Commands.Delete
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IRepository<Project> _repository;
        private readonly IRepository<Contract> _contractRepository;

        public DeleteProjectCommandHandler(IRepository<Project> repository, IRepository<Contract> contractRepository)
        {
            _repository = repository;
            _contractRepository = contractRepository;
        }

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if(entity is null)
                throw new NotFoundException(nameof(Project), request.Id, 422);

            var hasContracts =  _contractRepository.HasElement(c => c.ProjectId == entity.ProjectId);
            if (hasContracts)
            {
                // TODO: Add functional test for this behaviour.
                throw new DeleteFailureException(nameof(Project), request.Id, "There are existing contracts associated with this product.");
            }

            await _repository.DeleteAsync(entity, cancellationToken);
        }
    }
}