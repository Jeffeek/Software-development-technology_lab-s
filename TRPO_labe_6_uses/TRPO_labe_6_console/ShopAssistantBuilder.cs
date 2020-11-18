using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_console
{
    public class ShopAssistantBuilder
    {
        public ShopAssistant Build()
        {
            string name = GetName();
            int age = GetAge();
            DateTime date = GetHiringDate();

            return new ShopAssistant(name, age, date);
        }

        private string GetName()
        {
            Console.WriteLine("Введите имя работника: ");
            var name = Console.ReadLine();
            return name;
        }

        private int GetAge()
        {
            Console.WriteLine("Введите возраст работника: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                return Math.Abs(age);
            }
            throw new Exception();
        }

        private DateTime GetHiringDate()
        {
            Console.WriteLine("Введите дату найма работника: ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime time))
            {
                return time;
            }
            throw new Exception();
        }
    }
}
