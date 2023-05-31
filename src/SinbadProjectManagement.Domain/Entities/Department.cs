using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Domain.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}