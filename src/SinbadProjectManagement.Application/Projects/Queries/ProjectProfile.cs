using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Application.Projects.Queries
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project,ProjectDto>()
            .ForMember(x => x.DepartmentName, opt => opt.MapFrom(p => p.Department != null ? p.Department.Name : string.Empty))
            .ForMember(x => x.FunderName, opt => opt.MapFrom(p => p.Funder != null ? p.Funder.Name : string.Empty));
        }
    }
}