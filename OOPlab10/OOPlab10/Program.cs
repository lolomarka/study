using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OOPlab10
{
    public class Program
    {
        static List<Person>        persList = null;
        static List<IExecutable>   IExecList = null;

        public static void Main(string[] args)
        {
            

            Wait();
            Query1(true);   //вывести мужиков из списка людей
            Wait();
            Query1(false);  //вывести женщин из списка людей
            Wait();
            Query2();       //Вывести количество инженеров на заводе
            Wait();
            Query3();       //Вывести количество инженеров в подразделение  
            Wait();
            CreateIExecutableList();    //Создать список IExecutable
            PrintIExecutableList();     //Печать созданного списка
            SortExample();          //Пример сортировки с IComparer
            Wait();
            SearchExample();
            Wait();
        }

        public static void SearchExample()
        {
            persList = null;
            GenerateList(out persList,5,5,5);

            PrintList(persList);

            Print("Пример работы поиска:\nВведите имя для поиска(из списка выше):");
            SearchName(persList, new SortByName(), Console.ReadLine());

        }

        public static void SortExample()
        {
            persList = null;
            GenerateList(out persList,5,5,5);

            PrintList(persList);

            //Пример сортировки
            SortWithComparer(ref persList, new SortByName());
            PrintList(persList);
        }

        public static void CreateIExecutableList()
        {
            GenerateList(out IExecList,3,4,3);
        }

        public static void PrintIExecutableList()
        {
            PrintList(IExecList);
        }

        public static void GenerateList(out List<Person> lst, int EmployeeCount, int EngineerCount, int AdministrationCount)
        {
            lst = new List<Person>();

            for(int i = 0; i < EmployeeCount;i++)
            {
                lst.Add(Generator.CreateNewEmployee());
            }
            for(int i = 0; i < EngineerCount;i++)
            {
                lst.Add(Generator.CreateNewEngineer());
            }
            for (int i = 0; i < AdministrationCount; i++)
            {
                lst.Add(Generator.CreateNewAdministration());
            }
        }

        public static void GenerateList(out List<IExecutable> lst, int EmployeeCount, int EngineerCount, int AdministrationCount)
        {
            lst = new List<IExecutable>();

            for(int i = 0; i < EmployeeCount;i++)
            {
                lst.Add(Generator.CreateNewEmployee());
            }
            for(int i = 0; i < EngineerCount;i++)
            {
                lst.Add(Generator.CreateNewEngineer());
            }
            for (int i = 0; i < AdministrationCount; i++)
            {
                lst.Add(Generator.CreateNewAdministration());
            }
        }


        /// <summary>
        /// Проверка списка на инициализацию и размер
        /// </summary>
        /// <param name="list">Список</param>
        /// <typeparam name="T">Любой</typeparam>
        /// <returns>true - пуст или неиницилизирован, false - не пуст и инициализирован</returns>
         public static bool IsNullOrEmpty<T>(List<T> list)
        {
            if (IsNull(list))
            {
                return true;
            }
            else if (list.Count == 0)
            {
                Print("Список пуст");
                return true;
            }
            return false;
        }
        

        /// <summary>
        /// Проверка списка на инициализацию
        /// </summary>
        /// <param name="list">Список</param>
        /// <typeparam name="T">Любой тип данных</typeparam>
        /// <returns>true - неинициализирован / false - инициализирован</returns>
        public static bool IsNull<T>(List<T> list)
        {
            if (list == null)
            {
                Print("Список не создан");
                return true;
            }
            return false;
        }

        public static void Query1(bool man) //Имена всех лиц мужского (женского) пола.
        {
            persList = null;
            GenerateList(out persList,5,5,5);

            PrintList(persList);


            Console.WriteLine(man?"Мужские имена из списка:\n":"Женские имена из списка:\n");
            foreach(Person elem in persList)
            {
                if(man)
                {
                    if(elem.Sex == 'М')
                    {
                        Console.WriteLine(elem.Name);
                    }
                }
                else
                {
                    if(elem.Sex == 'Ж')
                    {
                        Console.WriteLine(elem.Name);
                    }
                }
            }
        }


        /// <summary>
        /// Печать списка Person
        /// </summary>
        /// <param name="lst">Список Person для печати</param>
        public static void PrintList(List<Person> lst)
        {
            if(IsNullOrEmpty(lst)) return;
            Console.WriteLine("Список персон: ");

            
            //С виртуальным методом 
            foreach(Person elem in lst)
            {
                Print("\n\nВызов виртуального метода: ");
                elem.ShowInfo();
                Print("\nВызов невиртуального медота: ");
                elem.ShowInfo_No_Virt();
            }

        }
        
        /// <summary>
        /// Печать списка IExecutable
        /// </summary>
        /// <param name="lst">Список IExecutable для печати</param>
        public static void PrintList(List<IExecutable> lst)
        {
            if(IsNullOrEmpty(lst)) return;
            Console.WriteLine("Список персон: ");

            Print("Вызов виртуального метода: ");
            //С виртуальным методом 
            foreach(Person elem in lst)
            {
                elem.ShowInfo();
                Console.WriteLine();
            }

            Print("Вызов невиртуального метода: ");
            foreach(Person elem in lst)
            {
                elem.ShowInfo_No_Virt();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Печать массива персон
        /// </summary>
        /// <param name="Arr">Массив персон на печать</param>
        public static void PrintArrOfPerson(Person[] Arr)
        {
            for(int i = 0; i < Arr.Length;i++)
            {   
                Arr[i].ShowInfo();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Печать массива IExecutable
        /// </summary>
        /// <param name="Arr">Массив IExecutable на печать</param>
        public static void PrintArrOfIExecutable(IExecutable[] Arr)
        {
            for(int i = 0; i < Arr.Length;i++)
            {   
                Arr[i].ShowInfo();
                Console.WriteLine();
            }
        }


        public static void Query2()//Сколько инженеров на заводе
        {
            persList = null;

            GenerateList(out persList, 5, new Random().Next(3,10), 5);

            PrintList(persList);
            
            Wait();

            int cnt = 0;

            foreach(Person elem in persList)
            {
                if(elem is Engineer)
                {
                    cnt++;
                }
            }

            Console.WriteLine($"Кол-во инженеров на заводе: {cnt}");
        }

        public static void Query3() // Сколько инженеров трудятся в подразделении
        {
            persList = null;

            GenerateList(out persList, 2,10,2);

            int len = 0;
            foreach(Person pers in persList)
            {
                if(pers is Engineer)
                {
                    len++;
                }
            }

            List<Person> engList = new List<Person>();
            
            foreach(Person pers in persList)
            {
                if(pers is Engineer)
                    engList.Add(pers);
            }

            int[] subdArr = new int[16];

            foreach(Engineer eng in engList)
            {
                subdArr[eng.NumOfSubdivision-1]++;
            }

            Person[] engArr = engList.ToArray();

            PrintList(persList);
            Wait();
            PrintArrOfPerson(engArr);
            Wait();
            for(int i = 0; i < subdArr.Length; i++)
            {
                Console.Write($"\nКол-во инженеров в подразделение №{i+1} = {subdArr[i]}\n");
            }
        }

        public static void Print(string str)
        {
            Console.WriteLine(str);
        }

        static void Wait()
        {
            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey();
        }
    
        public static void SortByAge(ref List<Person> list)
        {
            Person[] a = list.ToArray();
            Array.Sort(a);
            list = a.ToList();

            Print("Список отсортирован по возрасту");
        }

        public static void SortWithComparer(ref List<Person> list, IComparer comparer)
        {
            Person[] a = list.ToArray();
            Array.Sort(a,comparer);
            list = a.ToList();

            Print("Список отсортирован");
        }
    
        public static int SearchName(List<Person> list, IComparer comparer, string Name)
        {
            SortWithComparer(ref list, comparer);

            Person[] arr = list.ToArray();

            int index = Array.BinarySearch(arr,new Person(Name, 1, 'М'), comparer);

            if(index > -1)
            {
                Print($"Номер в списке: {index + 1}");
                list[index].ShowInfo();
                return index;
            }
            else
            {
                Print("ФИО не найдено");
                return -1;
            }
        }

    
    }   
}
