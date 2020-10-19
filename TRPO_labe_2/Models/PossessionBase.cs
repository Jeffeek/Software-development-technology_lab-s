using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_2.Interfaces;

namespace TRPO_labe_2.Models
{
    abstract class PossessionBase : IPossession
    {
        public string Name => GetType().Name;
        public abstract string Info();
        public int CountOfClerks { get; } = new Random().Next(5,30);
    }
}
