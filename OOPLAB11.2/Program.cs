using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using Microsoft.VisualBasic;
using OOPlab10;
namespace OOPLAB11
{
    class Program
    {
        static private SortedDictionary<string, Person> mySortedDictionary = new SortedDictionary<string, Person>();
        static void Main(string[] args)
        {
            // Menu.RunMenu();
            mySortedDictionary.Add("Шеретов Марк", new Administration());
            foreach(KeyValuePair<string,Person> kvp in mySortedDictionary)
            {
                Console.WriteLine("Key = {0}, Value = {1}",kvp.Key,kvp.Value.Name);
            }
            
        }
    }
}
