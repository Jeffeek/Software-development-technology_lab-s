using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_labe_5.States
{
    class Overload : IState
    {
        public void DoAction()
        {
            Console.WriteLine("Я перегрузился, теперь меня надо чинить! :(");
        }
    }
}
