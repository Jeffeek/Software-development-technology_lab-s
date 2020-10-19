using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_2.Interfaces;
using TRPO_labe_2.Models;

namespace TRPO_labe_2
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrganization oilOrganization = new OilAndGasCompany();
            IOrganization insuranceOrganization = new InsuranceCompany();

            Console.WriteLine(oilOrganization.Name);
            Console.WriteLine(insuranceOrganization.Name);
            Console.WriteLine(oilOrganization.Info());
            Console.WriteLine(insuranceOrganization.Info());
        }
    }
}
