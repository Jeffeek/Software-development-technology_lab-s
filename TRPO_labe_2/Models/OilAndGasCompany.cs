using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_2.Interfaces;

namespace TRPO_labe_2.Models
{
    class OilAndGasCompany : OrganizationBase
    {
        public override void AddPossession()
        {
            Possessions.Add(new Factory());
        }

        public override string Info()
        {
            return "Мы компания нефтегазовая! У нас есть заводы!";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
