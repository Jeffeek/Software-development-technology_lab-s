using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_console
{
    public class ProductBuilder
    {
        public Product Build()
        {
            string name = GetName();
            int price = GetPrice();
            return new Product(name, price);
        }

        private string GetName()
        {
            Console.WriteLine("Введите название товара: ");
            string name = Console.ReadLine();
            return name;
        }

        private int GetPrice()
        {
            Console.WriteLine("Введите цену товара");
            if (int.TryParse(Console.ReadLine(), out int price))
            {
                return Math.Abs(price);
            }
            throw new Exception();
        }
    }
}
