using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Domain.Entities
{
    public class Contract
    {
        public int ContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int BeneficiaryId { get; set; }
        public Beneficiary Beneficiary { get; set; }
    }
}