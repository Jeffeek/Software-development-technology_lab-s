using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_console
{
    //TODOL нихера не сделано
    class ShopsContext
    {
        private List<Shop> Shops;

        public ShopsContext()
        {
            Shops = GetBoolAnswer("Десериализовать ли магазины из файла? 1. Да\n2.Нет", x => x == 1) ? new ShopsDeserializer($"{Directory.GetCurrentDirectory()}//shops.xml").GetAll() : new List<Shop>();
            StartContext();
        }

        private void StartContext()
        {
            while (true)
            {
                Console.WriteLine("1. Добавить магазин");
                Console.WriteLine("2. Сохранить текущее состояние в файле");
                Console.WriteLine("3. Контроллер продавца");
                Console.WriteLine("4. Добавить товар в магазин");
                Console.WriteLine("");
            }
        }

        private void ProductCommands()
        {
            Console.WriteLine("1. Продать товар");
        }

        private bool GetBoolAnswer(string text, Func<int, bool> func)
        {
            Console.WriteLine(text);
            string answer = Console.ReadLine();
            if (int.TryParse(answer, out int answerResult))
            {
                if (func.Invoke(answerResult))
                {
                    return true;
                }
            }

            return false;
        }

        private bool GetBoolAnswer(string text, Func<string, bool> func)
        {
            Console.WriteLine(text);
            string answer = Console.ReadLine();
            if (func.Invoke(answer))
                return true;
            return false;
        }
    }
}
