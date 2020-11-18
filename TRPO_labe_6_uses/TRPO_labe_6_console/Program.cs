using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_console
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            List<Ebanis> integers = new List<Ebanis>();
            EBAT();
            for (int i = 0; i < int.MaxValue; i++)
            {
                watch.Reset();
                watch.Start();
                var item = new Ebanis();
                integers.Add(item);
                watch.Stop();
                if (watch.ElapsedTicks == 1488)
                {
                    Console.WriteLine("iteration");
                    Console.WriteLine(watch.Elapsed);
                }
                    
            }
            var context = new ShopsContext();
            Console.ReadKey();
        }


        static async Task EBAT()
        {
            while (true)
                await Task.Run(() =>
                {
                    Console.BackgroundColor = (ConsoleColor) rnd.Next(0, 7);
                    Console.ForegroundColor = (ConsoleColor) rnd.Next(0, 7);
                });
        }
    }

    class Ebanis
    {
        public string hui = "";
        List<Vlad> list = new List<Vlad>();

        public Ebanis()
        {
            for (int i = 0; i < 1; i++)
            {
                list.Add(new Vlad());
                hui += "lol";
            }
        }
    }

    class Vlad
    {
        private string p = "";

        public Vlad()
        {
            for (int i = 0; i < 5; i++)
            {
                p += "pipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipippipipipipipipipipipipipipipipippipipipipipip";
                p += "popopopopopopop";
            }
        }
    }
}
