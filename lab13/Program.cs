using System;
using OOPlab10;

namespace lab13
{
    public class Program
    {
        public static int CompareByAge(Person p1, Person p2) => p1.Age.CompareTo(p2.Age);

        public static int CompareByName(Person p1, Person p2) => String.Compare(p1.Name, p2.Name, StringComparison.Ordinal);

        static void Main()
        {
            MyNewTree<Person> ll1 = new MyNewTree<Person>("COL_1");
            MyNewTree<Person> ll2 = new MyNewTree<Person>("COL_2");

            Journal<Person> j1 = new Journal<Person>("JOUR_1");
            Journal<Person> j2 = new Journal<Person>("JOUR_2");

            ll1.CountChanged += j1.AddCountChangeInfo;
            ll1.RefChanged += j1.AddRefChangeInfo;

            ll1.RefChanged+= j2.AddRefChangeInfo;
            ll2.RefChanged += j2.AddRefChangeInfo;
            
            Console.Write('\n');
            ll1.Print();
            ll2.Print();
            j1.Print();
            j2.Print();
            Console.Write('\n');


            for (int i = 0; i < 5; i++)
            {
                ll1.Add(Generator.CreateRandomHuman());
            }
            for (int i = 0; i < 5; i++)
            {
                ll2.Add(Generator.CreateRandomHuman());
            }
            
            
            
            Console.Write('\n');
            ll1.Print();
            ll2.Print();
            j1.Print();
            j2.Print();
            Console.Write('\n');
            
            
            Console.Write('\n');
            ll1.Print();
            ll2.Print();
            j1.Print();
            j2.Print();
            Console.Write('\n');
            
            Console.WriteLine(ll1.Size);
            
            
            ll1[0] = Generator.CreateNewEmployee().Base;
            ll2[0] = Generator.CreateRandomHuman();
            ll1[4] = new Person("ФФФФФФФФФФФФФФФФФФФФФФ", 10, 'М');
            ll2.Add(Generator.CreateRandomHuman());
            
            ll1.Print();
            ll2.Print();
            j1.Print();
            j2.Print();
            Console.Write('\n');
            
            
            ll1.Delete(ll1[4]);
            ll2.DeleteByKey(ll2[2]);
            
            ll1.Print();
            ll2.Print();
            j1.Print();
            j2.Print();
            Console.Write('\n');
            
            // ll1.Sort(CompareByAge);
            //
            // ll1.Print();
            //
            // ll1.Sort(CompareByName);
            //
            // ll1.Print();
        }
    }
}
