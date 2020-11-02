using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_labe_5.States
{
    class Movement : IState
    {
        public void DoAction()
        {
            Console.WriteLine("УРЯЯ, Я ЕДУУУУ");
        }
    }
}
