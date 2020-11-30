using System;
using System.Linq;
using System.Reflection;

namespace TRPO_labe_9
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(Animal);
            Console.WriteLine("\nИнформация о конструкторах: ");
            Console.WriteLine(String.Join(Environment.NewLine, type.GetConstructors().AsEnumerable()));

            Console.WriteLine("\nИнформация о свойствах: ");
            Console.WriteLine(String.Join(Environment.NewLine, type.GetProperties().AsEnumerable()));

            Console.WriteLine("\nИнформация о методах: ");
            Console.WriteLine(String.Join(Environment.NewLine, type.GetMethods().AsEnumerable()));

            Console.WriteLine("\nСвойства с аттрибутом Animal: ");
            var properties = type.GetProperties();
            var propWithAnimalAttribute =
                properties.Where(x => x.GetCustomAttributes(typeof(ОAttribute)) != null);
            Console.WriteLine(string.Join(Environment.NewLine, propWithAnimalAttribute));
        }
    }
}
