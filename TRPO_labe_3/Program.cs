using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_3.Classes.Models;

namespace TRPO_labe_3
{
    class Program
    {
        static void Main(string[] args)
        {
            FigureRandomer randomer = new FigureRandomer();
            var list = randomer.GetFigures();
            foreach (var fig in list)
            {
                Console.WriteLine(fig);
            }

            Console.ReadKey();
        }
    }
}
