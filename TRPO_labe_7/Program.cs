using System;
using TRPO_7_LevenshteinDistance;

namespace TRPO_labe_7
{
    class Program
    {
        static void Main(string[] args)
        {
            LevenshteinDistance levenshtein;
            bool max = false;
            int maxValue = 0;
            Console.WriteLine("Будем делать отдельное поле ввода для максимального расстояния? \n1. Да\n2. Нет");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                if (answer == 1)
                {
                    max = true;
                    Console.WriteLine("Введите максимум: ");
                    if (int.TryParse(Console.ReadLine(), out maxValue))
                    {
                        Console.WriteLine("Ок");
                    }
                    else
                    {
                        Console.WriteLine("Неа.");
                        max = false;
                    }
                }
            }
            while (true)
            {
                Console.WriteLine("Введите первую строку: ");
                var s1 = Console.ReadLine();
                Console.WriteLine("Введите вторую строку: ");
                var s2 = Console.ReadLine();
                levenshtein = new LevenshteinDistance(s1, s2);
                int differnce = levenshtein.CalculateLevenshteinDistance();
                if (max)
                {
                    if (differnce > maxValue)
                    {
                        Console.WriteLine("Строки разные!");
                    }
                }
                Console.WriteLine(differnce);
                Console.WriteLine();
            }
        }
    }
}
