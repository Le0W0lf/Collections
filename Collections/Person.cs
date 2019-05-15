using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    class Person
    {
        public string Name;
        public int Age;
        public string Class;
        public int Level;

        public Person(string name, int age, string clas, int level)
        {
            Name = name;
            Age = age;
            Class = clas;
            Level = level;
        }

        internal void Print()
        {
            Console.WriteLine($"{Name}, {Age} years, {Class} {Level}");
        }
    }
}
