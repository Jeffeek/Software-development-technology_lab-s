using System;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_console
{
    public class ShopBuilder
    {
        public Shop Build()
        {
            string name = GetName();
            return new Shop(name);
        }

        private string GetName()
        {
            Console.WriteLine("Введите имя магазина: ");
            string name = Console.ReadLine();
            return name;
        }
    }
}
