using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Domain.Entities
{
    public class Beneficiary
    {
        public int BeneficiaryId { get; set; }
        public string Name { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}