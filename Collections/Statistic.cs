using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Collections
{
    class Statistic
    {
        public int CountPersons, MaxLvl, MinLvl;
        public double AvgAge, AvgLvl;
        public string MostPopularClass;
        public Statistic(IEnumerable<Person> l)
        {
            CountPersons = l.Count();
            MaxLvl = l.Max(x => x.Level);
            MinLvl = l.Min(x => x.Level);
            AvgAge = l.Average(x => x.Age);
            AvgLvl = l.Average(x => x.Level);
        }

        internal void Print()
        {
            Console.WriteLine($"Count of heroes : {CountPersons}");
            Console.WriteLine($"Max level       : {MaxLvl}");
            Console.WriteLine($"Min level       : {MinLvl}");
            Console.WriteLine($"Average level   : {AvgLvl:N2}");
            Console.WriteLine($"Average age     : {AvgAge:N2}");
        }
    }
}
