using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_labe_2.Interfaces
{
    interface IPossession
    {
        string Info();
        int CountOfClerks { get; }
    }
}
