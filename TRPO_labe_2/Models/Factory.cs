using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_2.Interfaces;

namespace TRPO_labe_2.Models
{
    class Factory : PossessionBase
    {
        public override string Info()
        {
            return "Завод!";
        }
    }
}
