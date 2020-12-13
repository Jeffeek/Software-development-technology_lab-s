using System;

namespace TRPO_labe_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1000000;
            var tickets = new LuckyTicketContext();
            tickets.StartHunting(count);
            Console.ReadLine();
        }
    }
}
