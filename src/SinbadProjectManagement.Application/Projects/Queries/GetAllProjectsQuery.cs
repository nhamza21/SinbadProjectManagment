using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Application.Projects.Queries
{
    public class GetAllProjectsQuery : IRequest<ProjectListDto>
    {
        
    }

    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, ProjectListDto>
    {
        private readonly IRepository<Project> _repository;
        private readonly IMapper _mapper;

        public GetAllProjectsQueryHandler(IRepository<Project> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<ProjectListDto> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllAsync(cancellationToken);
            var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);

            var listDto = new ProjectListDto
            {
                ProjectDtos = projectDtos
            };

            return listDto;
        }
    }
}