using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_2.Models;

namespace TRPO_labe_2.Interfaces
{
    interface IOrganization
    {
        List<PossessionBase> Possessions { get; }
        void AddPossession();
        string Info();
    }
}
