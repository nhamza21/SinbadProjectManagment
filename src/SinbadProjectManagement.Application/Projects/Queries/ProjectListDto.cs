using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Application.Projects.Queries
{
    public class ProjectListDto
    {
        public IEnumerable<ProjectDto> ProjectDtos {get; set;} 
    }
}