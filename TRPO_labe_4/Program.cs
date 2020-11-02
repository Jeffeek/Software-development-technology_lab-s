using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_4.Real_Estate;

namespace TRPO_labe_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var cottage = new Cottage
                (
                300,
                320,
                7,
                2013,
                12,
                900000
                );
            var apartment = new Apartment(
                100,
                30,
                3,
                1998, 
                25,
                43000
                );
            var townhouse = new Townhouse
                (3000, 
                240, 
                10,
                2016,
                3,
                1200000
                );

            var calculator = new InsuranceСalculator();
            Console.WriteLine($"{nameof(cottage)} : {calculator.GetInsurance(cottage):F2}");
            Console.WriteLine($"{nameof(apartment)} : {calculator.GetInsurance(apartment):F2}");
            Console.WriteLine($"{nameof(townhouse)} : {calculator.GetInsurance(townhouse):F2}");

            Console.ReadKey();
        }
    }
}
