using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Application.Projects.Queries
{
    public class GetProjectQuery : IRequest<ProjectDto>
    {
        public int Id {get; set;}
    }

    public class GetProjectsQueryHandler : IRequestHandler<GetProjectQuery, ProjectDto>
    {
        private readonly IRepository<Project> _repository;
        private readonly IMapper _mapper;

        public GetProjectsQueryHandler(IRepository<Project> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if(project is null)
                throw new NotFoundException(nameof(Project), request.Id, 404);

            var projectDto = _mapper.Map<ProjectDto>(project);
            return projectDto;
        }
    }
}