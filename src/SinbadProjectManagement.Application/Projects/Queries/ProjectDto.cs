using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinbadProjectManagement.Domain.Entities;

namespace SinbadProjectManagement.Application.Projects.Queries
{
    public class ProjectDto
    {
       public int ProjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? FunderId { get; set; }
        public string FunderName { get; set; }
        public decimal? Amount { get; set; } 
    }
}