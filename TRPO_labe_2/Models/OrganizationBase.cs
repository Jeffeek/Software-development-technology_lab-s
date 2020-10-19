using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_2.Interfaces;

namespace TRPO_labe_2.Models
{
    abstract class OrganizationBase : IOrganization
    {
        public string Name => GetType().Name;
        public List<PossessionBase> Possessions { get; } = new List<PossessionBase>();
        public abstract void AddPossession();
        public abstract string Info();
        public int CountOfAllClerks() => Possessions.Sum(x => x.CountOfClerks);
    }
}
