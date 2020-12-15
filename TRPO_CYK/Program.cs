using System;
using System.Collections.Generic;

namespace TRPO_CYK
{
    class Program
    {
        static void Main(string[] args)
        {
            var rules = new List<Rule>()
            {
                new Rule('S', "AB"),
                new Rule('A', "CD"),
                new Rule('A', "CF"),
                new Rule('B', "c"),
                new Rule('B', "EB"),
                new Rule('C', "a"),
                new Rule('D', "b"),
                new Rule('E', "c"),
                new Rule('F', "AD")
            };
            //aaabbb - false
            //aaabbbcc - true
            var cyk = new CYK(rules);
            Console.WriteLine(cyk.Parse("aaabbbcc"));
            Console.WriteLine(cyk);
            Console.ReadLine();
        }
    }
}
