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

        public static SortedDictionary<string, Person> MySortedDictionary
        {
            get => mySortedDictionary;
            set => mySortedDictionary = value;
        }


        static void Main(string[] args)
        {
            Menu.RunMenu();
        }

        static public void AddElementToDictionary(SortedDictionary<string, Person> sortedDictionary)
        {
            Person p;
            
            int k = Tools.ChooseType();
            
            try
            {
                switch (k)
                {
                    case 1:
                        p = Generator.CreateNewEmployee();
                        sortedDictionary.Add(p.Name,p);
                        break;
                    case 2:
                        p = Generator.CreateNewEngineer();
                        sortedDictionary.Add(p.Name,p);
                        break;
                    case 3:
                        p = Generator.CreateNewAdministration();
                        sortedDictionary.Add(p.Name,p);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public void DeleteElementToDictionary(SortedDictionary<string, Person> sortedDictionary)
        {
            string keyName = Tools.InputString("Введите имя объекта для удаления: ");

            try
            {
                if (!sortedDictionary.Remove(keyName))
                {
                    throw new ArgumentException();
                }
                Console.WriteLine("Удаление произошло успешно");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        static public void PrintSortedDictionary(SortedDictionary<string, Person> sortedDictionary)
        {
            foreach (var VARIABLE in sortedDictionary)
            {
                Console.WriteLine("Ключевое имя: {0}",VARIABLE.Key);
                Console.WriteLine("Значение(Информация об объекте): ");
                VARIABLE.Value.ShowInfo();
                Console.WriteLine();
            }
        }
    }
}
