using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Domain.Entities
{
    public class Funder
    {
        public int FunderId { get; set; }
        public string Name { get; set; }
        public decimal MoneyProvided { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}