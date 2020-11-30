using System;
using System.Linq;

namespace TRPO_labe_8
{
    public delegate T Delegat<T>(params T[] args);
    class Program
    {
        static void Main(string[] args)
        {
            Delegat<int> inta = GetMax;
            var context = new DelegateContext();
            Console.WriteLine(context.TestDelegate(inta, 1, 2, 3, 4));
            Console.WriteLine(context.TestDelegate<int>((args) => args.Max(), 1,2,3,4));
            Console.WriteLine(context.TestFuncDelegate(GetMax, 1, 2, 3, 4));
        }

        static int GetMax(params int[] args)
        {
            return args.Max();
        }
    }
}
