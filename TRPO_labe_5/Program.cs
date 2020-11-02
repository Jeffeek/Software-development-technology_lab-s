using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_5.Model;

namespace TRPO_labe_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var lift = new ServiceLift {Carrying = 5000, CurrentFloor = 1, ProbabilityOfPowerOutage = 25};
            lift.Load(1000);
            lift.CallOnFloor(10);
            
            Console.ReadKey();
        }
    }
}
