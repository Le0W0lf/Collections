using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Program
    {
        public static List<Person> persons;// = new List<Person>();
        static void Main(string[] args)
        {
            { 
            /*string[] DaysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednsday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };*/

            /*List<string> DaysOfWeek = new List<string>
             {
                 "Monday",
                 "Tuesday",
                 "Wednsday",
                 "Thursday",
                 "Friday",
                 "Saturday",
                 "Sunday"
             };
             var temp=DaysOfWeek.Take(10);
             /*DaysOfWeek.Add("Monday");
             DaysOfWeek.Add("Tuesday");
             DaysOfWeek.Add("Wednsday");
             DaysOfWeek.Add("Thursday");
             DaysOfWeek.Add("Friday");
             DaysOfWeek.Add("Saturday");
             DaysOfWeek.Add("Sunday");*/

            /*foreach(string s in DaysOfWeek)
            {
                Console.WriteLine(s);
            }*/

            //int sum = ForParam( 1, 2, 3, 4, 5, 6 );

            //Console.WriteLine(sum);
            /*long a = long.Parse(Console.ReadLine());
            Console.WriteLine(ForInt(a).PadLeft(15));*/
            //Console.WriteLine(2_000_000);
        }


            persons = new List<Person>();
            AddPerson();
            //Print(persons.OrderBy(x=>x.Level).ThenBy(x=>x.Age));
            Print(persons);
            WorkWithUser(persons);
            
        }

        public static string ForInt(long a)
        {
            return $"{a:### ### ### ###}".Trim();
        }

        public static int ForParam(params int[] arr)
        {
            int sum = 0;
            foreach (int el in arr)
            {
                sum += el;
            }
            return sum;
        }

        public static void AddPerson()
        {
            persons.Add(new Person("Taman", 25, "warrior", 5));
            persons.Add(new Person("Garret", 101, "rogue", 6));
            persons.Add(new Person("Oliver", 55, "warlock", 5));
            persons.Add(new Person("Amrock", 30, "paladin", 3));
            persons.Add(new Person("Yulik", 20, "bard", 5));
            persons.Add(new Person("Almi", 98, "ranger", 4));
            persons.Add(new Person("Shanayra", 113, "monk", 5));
            persons.Add(new Person("Bidayn", 108, "rogue", 3));
            persons.Add(new Person("Lys", 32, "paladin", 3));
            persons.Add(new Person("Lora", 36, "priest", 3));
            persons.Add(new Person("Oliver2", 55, "warlock", 5));
        }

        public static void OutInfo()
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine("SORT    to sort");
            Console.WriteLine("FILT    to filter");
            Console.WriteLine("PRINT   to print");
            Console.WriteLine("TAKE    to take first N");
            Console.WriteLine("GROUP   to group");
            Console.WriteLine("STAT    to statistics");
            Console.WriteLine();
            Console.WriteLine("EX1     to exercise 1");
            Console.WriteLine("EX2     to exercise 2");
            Console.WriteLine("etc.");
            Console.WriteLine();
            Console.WriteLine("QUIT    to quit");


        }

        public static void WorkWithUser(IEnumerable<Person> l)
        {
            bool work = true;
            while (work)
            {
                OutInfo();
                string s = Console.ReadLine();
                switch (s.ToLower())
                {
                    case "sort":
                        l=Sort(l);
                        break;
                    case "filt":
                        l=Filt(l);
                        break;
                    case "print":
                        l = persons;
                        Console.Clear();
                        Print(l);
                        break;
                    case "quit":
                        work = false;
                        break;
                    case "take":
                        l=Take(l);
                        break;
                    case "group":
                        Group(l);
                        break;
                    case "stat":
                        Stat(l);
                        break;
                    case "ex1":
                        Exercise1();
                        break;
                    case "ex2":
                        Exercise2();
                        break;
                    case "ex3":
                        Exercise3();
                        break;
                    case "ex4":
                        Exercise4();
                        break;
                    case "ex5":
                        Exercise5();
                        break;
                    case "ex6":
                        Exercise6();
                        break;
                    case "ex7":
                        Exercise7();
                        break;
                    case "ex8":
                        Exercise8();
                        break;
                    case "ex9":
                        Exercise9();
                        break;
                    case "ex10":
                        Exercise10();
                        break;
                    case "ex11":
                        Exercise11();
                        break;
                    case "ex12":
                        Exercise12();
                        break;
                    case "ex13":
                        Exercise13();
                        break;
                    default:
                        Console.WriteLine("Something do wrong. Try again.");
                        break;
                }
            }
        }

        private static void Stat(IEnumerable<Person> l)
        {
            Console.Clear();
            Statistic statistic = new Statistic(l);
            statistic.Print();
        }

        private static void Group(IEnumerable<Person> l)
        {
            Console.Clear();
            Console.WriteLine("name / age / class / lvl");
            string s = Console.ReadLine();
            switch (s.ToLower())
            {
                case "name":
                    Console.WriteLine("Realy?");
                    break;
                case "age":
                    var groupA = l.OrderBy(x => x.Age).GroupBy(x => x.Age).Select(x => new { x.Key, Count = x.Count()});
                    foreach (var t in groupA)
                    {
                        Console.WriteLine($"{t.Key} years : {t.Count} heroes");
                    }
                    break;
                case "class":
                    var groupC = l.OrderBy(x => x.Class).GroupBy(x => x.Class)
                        .Select(x => new { x.Key, Count = x.Count(), Pers = x.Select(y => y) });
                    foreach (var t in groupC)
                    {
                        Console.WriteLine($"{t.Key} : {t.Count} heroes");
                        Print(t.Pers);
                        Console.WriteLine();
                    }
                    break;
                case "lvl":
                    var groupL = l.OrderBy(x => x.Level).GroupBy(x => x.Level)
                        .Select(x => new { x.Key, Count = x.Count(), Pers = x.Select(y => y) });
                    foreach (var t in groupL)
                    {
                        Console.WriteLine($"{t.Key} level : {t.Count} heroes");
                        Print(t.Pers);
                        Console.WriteLine();
                    }
                    break;
                default:
                    Console.WriteLine("Something do wrong. Try again.");
                    break;
            }
        }

        private static IEnumerable<Person> Take(IEnumerable<Person> l)
        {
            Console.Clear();
            Console.WriteLine("Count of elements");
            int n = int.Parse(Console.ReadLine());
            Print(l.Take(n));
            return l.Take(n);
        }

        private static IEnumerable<Person> Sort(IEnumerable<Person> l)
        {
            Console.Clear();
            Console.WriteLine("name / age / class / lvl         + desc(if want)");
            IEnumerable<Person> res=l;
            bool desc = false;
            string s = Console.ReadLine();
            var t = s.Split(' ');
            if (t.Length > 1 && t[1].ToLower() == "desc") desc = true;
            switch(t[0])
            {
                case "name":
                    if(desc)
                        res = Print(l.OrderByDescending(x => x.Name));
                    else
                        res = Print(l.OrderBy(x => x.Name));
                    break;
                case "age":
                    if (desc)
                        res = Print(l.OrderByDescending(x => x.Age));
                    else
                        res = Print(l.OrderBy(x => x.Age));
                    break;
                case "class":
                    if (desc)
                        res = Print(l.OrderByDescending(x => x.Class));
                    else
                        res = Print(l.OrderBy(x => x.Class));
                    break;
                case "lvl":
                    if (desc)
                        res = Print(l.OrderByDescending(x => x.Level));
                    else
                        res = Print(l.OrderBy(x => x.Level));
                    break;
                default:
                    Console.WriteLine("Something do wrong. Try again.");
                    break;
            }
            return res;
        }

        private static IEnumerable<Person> Filt(IEnumerable<Person> l)
        {
            Console.Clear();
            Console.WriteLine("name {start of name}");
            Console.WriteLine("age {?} {number}");
            Console.WriteLine("class {name class}");
            Console.WriteLine("lvl {?} {number}");
            IEnumerable<Person> res=l;
            string s = Console.ReadLine();
            var t = s.Split(' ');
            switch (t[0])
            {
                case "name":
                    res = Print(persons.Where(x => x.Name.StartsWith(t[1])));
                    break;
                case "age":
                    if (t[1] == "<")
                        res = Print(persons.Where(x => x.Age < int.Parse(t[2])));
                    if (t[1] == ">")
                        res = Print(persons.Where(x => x.Age > int.Parse(t[2])));
                    if (t[1] == "=")
                        res = Print(persons.Where(x => x.Age == int.Parse(t[2])));
                    
                    break;
                case "class":
                    res = Print(persons.Where(x => x.Class.StartsWith(t[1])));
                    break;
                case "lvl":
                    if (t[1] == "<")
                        res = Print(persons.Where(x => x.Level < int.Parse(t[2])));
                    if (t[1] == ">")
                        res = Print(persons.Where(x => x.Level > int.Parse(t[2])));
                    if (t[1] == "=")
                        res = Print(persons.Where(x => x.Level == int.Parse(t[2])));
                    break;
                default:
                    Console.WriteLine("Something do wrong. Try again.");
                    break;
            }
            return res;
        }

        public static IEnumerable<Person> Print(IEnumerable<Person> l)
        {
            //Console.Clear();
            foreach (var p in l)
            {
                p.Print();
            }
            return l;
        }
        
        public static void Exercise1()
        {
            Console.Clear();
            var sub1 = persons.Where(x => x.Age > 50 && x.Age < 100 ).OrderBy(x=>x.Name);
            var sub2 = from x in persons
                       where x.Age > 50 && x.Age < 100
                       orderby x.Name
                       select x;
            Print(sub1);
            Console.WriteLine();
            Print(sub2);
        }

        public static void Exercise2()
        {
            Console.Clear();
            var sub1 = persons.OrderBy(x=>x.Name).Take(5).OrderByDescending(x=>x.Name);
            var sub2 = from x in (from y in persons orderby y.Name select y).Take(5)
                       orderby x.Name descending
                       select x;

                       
            Print(sub1);
            Console.WriteLine();
            Print(sub2);
        }

        public static void Exercise3()
        {
            Console.Clear();
            var sub1 = persons.OrderBy(x => x.Level).ThenBy(x=>x.Class).ThenBy(x=>x.Name);
            var sub2 = from x in persons
                       orderby x.Level, x.Class, x.Name
                       select x;
            Print(sub1);
            Console.WriteLine();
            Print(sub2);
        }

        public static void Exercise4()
        {
            Console.Clear();
            var sub1 = persons.Where(x=>x.Class=="rogue").OrderBy(x=>x.Name);
            var sub2 = from x in persons
                       where x.Class == "rogue"
                       orderby x.Name
                       select x;
            Print(sub1);
            Console.WriteLine();
            Print(sub2);
        }

        public static void Exercise5()
        {
            Console.Clear();
            var sub1 = persons.OrderBy(x => x.Level).ThenBy(x=>x.Name).GroupBy(x => x.Level)
                .Select(x => new { x.Key, Count = x.Count(), Persons = x.Select(y => y.Name) });
            var sub2 = from x in persons
                       orderby x.Level, x.Name
                       group x by x.Level into y
                       select new
                       {
                           y.Key,
                           Count = y.Count(),
                           Persons = from z in y select z.Name
                       };
            foreach(var t in sub2)
            {
                Console.WriteLine($"{t.Key} level {t.Count} heroes : ");
                foreach(var temp in t.Persons)
                {
                    Console.WriteLine(temp);
                }
            }
        }

        public static void Exercise6()
        {
            Console.Clear();
            List<ClassForJoin> newpersons = new List<ClassForJoin>();
            newpersons.Add(new ClassForJoin("warrior", 1));
            newpersons.Add(new ClassForJoin("warlock", 2));
            newpersons.Add(new ClassForJoin("paladin", 3));
            newpersons.Add(new ClassForJoin("monk", 4));
            newpersons.Add(new ClassForJoin("rogue", 5));
            var sub1 = persons.Join(newpersons, x => x.Class, y => y.Class, (x, y) => new { Name = x.Name, Code = y.Code });
            var sub2 = from x in persons
                       join y in newpersons on x.Class equals y.Class
                       select new { Name = x.Name, Code = y.Code };
            foreach(var t in sub2)
            {
                Console.WriteLine($"{t.Name} {t.Code}");
            }
        }

        public static void Exercise7()
        {
            Console.Clear();
            List<Years> years = new List<Years>();
            //Console.WriteLine("list start");
            for (int i = 0; i < 1000; i++)
            {
                years.Add(new Years(1, 12, "baby"));
                years.Add(new Years(13, 19, "teen"));
                years.Add(new Years(20, 30, "young"));
                years.Add(new Years(31, 50, "mediumm"));
                years.Add(new Years(51, 100, "old"));
                years.Add(new Years(100, int.MaxValue, "not human"));
            }

            //Console.WriteLine("list created");

            var sub1 = persons.SelectMany(y => years, (x, y) => new { Name = x.Name, Age = y.Name, L = y.L, R = y.R, CurAge = x.Age }).
                Where(x => (x.CurAge >= x.L && x.CurAge <= x.R)).Select(x=>new{ Name = x.Name, Age = x.Age }).OrderBy(x=>x.Name);

            var sub2 = from x in persons
                       from y in years
                       where x.Age >= y.L && x.Age <= y.R
                       orderby x.Name
                       select new { Name = x.Name, Age = y.Name };


            //var sub3 = persons.Zip(years, (x, y) => new { Name = x.Name, Age = y.Name, L = y.L, R = y.R, CurAge = x.Age });
            //Where(x => (x.CurAge >= x.L && x.CurAge <= x.R)).Select(x => new { Name = x.Name, Age = x.Age }).OrderBy(x => x.Name);

            foreach (var t in sub1)
            {
                Console.WriteLine($"{t.Name} {t.Age}");
            }
            Console.WriteLine();
            foreach (var t in sub2)
            {
                Console.WriteLine($"{t.Name} {t.Age}");
            }
            
        }

        public static void Exercise8()
        {
            Console.Clear();

            var sub1 = persons.TakeWhile(x => x.Level > 3);
            var sub2 = persons.SkipWhile(x => x.Level > 3);
            Print(sub1);
            Console.WriteLine();
            Print(sub2);
        }

        public static void Exercise9()
        {
            Console.Clear();

            var sub1_1 = persons.Where(x => x.Level >=4);
            var sub1_2 = persons.Where(x => x.Level <=5);
            var sub1 = sub1_1.Intersect(sub1_2);
            var sub2 = sub1_1.Union(sub1_2);
            var sub3 = sub1_1.Except(sub1_2);
            Console.WriteLine("Intersect");
            Print(sub1);
            Console.WriteLine("\nUnion");
            Print(sub2);
            Console.WriteLine("\nExcept");
            Print(sub3);
            /*Console.WriteLine();
            Print(sub1_1);
            Console.WriteLine();
            Print(sub1_2);*/
        }

        public static void Exercise10()
        {
            Console.Clear();

            var sub1 = persons.Prepend(new Person("newperson",0,"none",0));
            Print(sub1);
        }

        public static void Exercise11()
        {
            Console.Clear();

            var sub1 = persons.Select(x=>x.Name);
            foreach(var t in sub1)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();
            persons.RemoveAt(5);
            foreach (var t in sub1)
            {
                Console.WriteLine(t);
            }

        }

        public static void Exercise12()
        {
            var a = 0b_10;
            Console.Clear();
            Action<int> action = x => Console.WriteLine(x);
            Func<int> func = (()=>10);
            var sub1 = from x in persons
                       group x by x.Class;
            foreach(var t in sub1)
            {
                Console.WriteLine(t.Key);
            }
        }

        public static void Exercise13()
        {
            Console.Clear();
            var sub1 = persons.OrderBy(x => x.Name);
            persons.Add(new Person("Abc", 10, "rogue", 25));
            Print(sub1);
            Console.WriteLine();
            Print(persons);
        }
    }
}
