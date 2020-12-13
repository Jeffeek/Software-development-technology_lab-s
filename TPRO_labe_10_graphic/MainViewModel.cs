using OxyPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPRO_labe_10_graphic
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Points = new List<DataPoint>();
            StartHunting(100000);
            FillOxy();
        }

        public IList<DataPoint> Points { get; private set; }

        private void FillOxy()
        {
            var list = new List<DataPoint>();
            for (int i = 0; i < 10; i++)
                list.Add(Points[i]);
        }

        public IEnumerable<int> TicketGenerator()
        {
            var rnd = new Random();
            while (true)
                yield return rnd.Next(100000, 1000000);
        }

        private void StartHunting(int count)
        {
            for (int i = 1; i <= 10; i++)
            {
                var nums = TicketGenerator().Take(count).ToArray();
                int luckyTicketsCount = nums.Count(x => IsLucky(x));
                Points.Add(new DataPoint(i, (double)luckyTicketsCount / count * 100));
                Debug.WriteLine($"Всего билетов: {count}\nСчастливых билетов: {luckyTicketsCount}\nПроцент счастливых билетов: {((double)luckyTicketsCount / count * 100):0.###}%");
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
