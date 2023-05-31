using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Domain.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? FunderId { get; set; }
        public Funder Funder { get; set; }
        public decimal? Amount { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}