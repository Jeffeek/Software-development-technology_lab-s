using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_labe_5.States
{
    class NoPower : IState
    {
        public void DoAction()
        {
            Console.WriteLine("У меня нет энергии :(");
        }
    }
}
