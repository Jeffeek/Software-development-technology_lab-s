using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Media;

namespace TRPO_labe_10
{
    public class LuckyTicketContext
    {
        private List<int> _percents = new List<int>();

        public IEnumerable<int> TicketGenerator()
        {
            var rnd = new Random();
            while (true)
                yield return rnd.Next(100000, 1000000);
        }

        public void StartHunting(int count)
        {
            for (int i = 0; i < 10; i++)
            {
                var nums = TicketGenerator().Take(count).ToArray();
                int luckyTicketsCount = nums.Count(x => IsLucky(x));
                _percents.Add(luckyTicketsCount);
                //Console.WriteLine($"Всего билетов: {count}\nСчастливых билетов: {luckyTicketsCount}\nПроцент счастливых билетов: {((double)luckyTicketsCount / count * 100):0.###}%");
            }
        }

        private bool IsLucky(int number)
        {
            int firstHalf = int.Parse(number.ToString().Substring(0, 3));
            int secondHalf = int.Parse(number.ToString().Substring(3, 3));
            return firstHalf.ToString().Select(x => int.Parse(x.ToString())).Sum() == secondHalf.ToString().Select(x => int.Parse(x.ToString())).Sum();
        }
    }
}
