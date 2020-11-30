using System;
using System.Collections.Generic;
using System.Text;

namespace TRPO_labe_9
{
    public class Animal
    {
        [О]
        public string Name { get; set; }

        [О]
        public int Age { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Animal()
        {
        }

        public static string Voice() => "Звук животного!";

        public override string ToString() => $"Name : {Name}, Age : {Age}";
    }
}
