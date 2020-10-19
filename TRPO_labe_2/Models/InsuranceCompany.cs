using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_labe_2.Models
{
    class InsuranceCompany : OrganizationBase
    {
        public override List<PossessionBase> Possessions { get; }
        public override void AddPossession()
        {
            Possessions.Add(new Office());
        }
        public override string Info()
        {
            return "Страховая компания!";
        }
    }
}
