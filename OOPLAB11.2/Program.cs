using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using OOPlab10;
namespace OOPLAB11
{
    class Program
    {
        private static Queue<Person> queue;
        private static Queue<Person> cQueue = new Queue<Person>();

        public static Queue<Person> QueueProperty
        {
            get
            {
                return queue;
            }
            set
            {
                queue = value;
            }
        }

        public static Queue<Person> CQueueProperty
        {
            get
            {
                return cQueue;
            }
            set
            {
                cQueue = value;
            }
            
        }
        
        
        static void Main(string[] args)
        {
            Menu.RunMenu();
        }

        ///Task1////
        public static void CreateQueue()
        {
            try
            {
                queue = new Queue<Person>();
                GC.Collect();
                Console.WriteLine("Операция выполнена успешно");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Ошибка операции");
                throw;
            }
        }

        public static void FillQueueRnd()
        {
            int empNum = Tools.InputNumOfElements("Количество элементов класса Employee");
            int engNum = Tools.InputNumOfElements("Количество элементов класса Engineer");
            int admNum = Tools.InputNumOfElements("Количество элементов класса Administration");

            for (int i = 0; i < empNum; i++)
            {
                Employee emp = Generator.CreateNewEmployee();
                emp.ShowInfo();
                queue.Enqueue(emp);
            }
            
            for (int i = 0; i < engNum; i++)
            {
                Employee eng = Generator.CreateNewEngineer();
                eng.ShowInfo();
                queue.Enqueue(eng);
            }
            
            for (int i = 0; i < admNum; i++)
            {
                Employee adm = Generator.CreateNewAdministration();
                adm.ShowInfo();
                queue.Enqueue(adm);
            }
            
            Console.WriteLine("Операция выполнена успешно");
            GC.Collect();
        }
        public static void FillQueueMan()
        {
            int empNum = Tools.InputNumOfElements("Количество элементов класса Employee");
            int engNum = Tools.InputNumOfElements("Количество элементов класса Engineer");
            int admNum = Tools.InputNumOfElements("Количество элементов класса Administration");

            for (int i = 0; i < empNum; i++)
            {
                Console.Clear();
                Console.WriteLine("\tРабочий");
                Employee emp = Tools.EmployeeConstructorDialog();
                emp.ShowInfo();
                queue.Enqueue(emp);
            }
            
            for (int i = 0; i < engNum; i++)
            {
                Console.Clear();
                Console.WriteLine("\tИнженер");
                Employee eng = Tools.EngineerConstructorDialog();
                eng.ShowInfo();
                queue.Enqueue(eng);
            }
            
            for (int i = 0; i < admNum; i++)
            {
                Console.Clear();
                Console.WriteLine("\tРаботник администрации");
                Employee adm = Tools.AdministrationConstructorDialog();
                adm.ShowInfo();
                queue.Enqueue(adm);
            }
            
            Console.WriteLine("Операция выполнена успешно");
            GC.Collect();
        }
        
        static public void PrintQueuePerson(Queue<Person> q)
        {
            if (Tools.IsNullOrEmpty(q))
            {
                Console.WriteLine("Нечего выводить!");
                return;
            }
            var myCollection = queue;
            foreach (Object obj in myCollection)
            {
                Person p = obj as Person;
                try
                {
                    p.ShowInfo();
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                
                Console.WriteLine();
            }
        }

        static public void EnqueueToQueue()
        {
            try
            {
                    
                    
                if (Tools.IsNull(queue))
                {
                    throw new Exception("Некуда добавлять элемент!");
                }

                int k = Tools.ChooseType("Выберите тип для добавления: ");
                
                switch (k)
                    {
                        case 1:
                            queue.Enqueue(Tools.EmployeeConstructorDialog());
                            break;
                        case 2:
                            queue.Enqueue(Tools.EngineerConstructorDialog());
                            break;
                        case 3:
                            queue.Enqueue(Tools.AdministrationConstructorDialog());
                            break;
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            
            
        }

        static public void DequeueFromQueue()
        {
            try
            {
                Person p = queue.Dequeue();
                p.ShowInfo();
                Console.WriteLine("Элемент успешно извлечён.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        #region Query1region
        static public void Query1()
        {
            try
            {
                if (Tools.IsNullOrEmpty(queue))
                    throw new Exception("Невозможно исполнить запрос!");
                
                Console.WriteLine("Вывести кол-во элементов определённого типа");
            
                int k = Tools.ChooseType("Выберите тип: ");
                Console.Write("Элементов указанного типа: ");
                switch (k)
                {
                    case 1:
                        Console.WriteLine(CountTypes<Employee>(queue));
                        break;
                    case 2:
                        Console.WriteLine(CountTypes<Engineer>(queue));
                        break;
                    case 3:
                        Console.WriteLine(CountTypes<Administration>(queue));
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        static private int CountTypes<T>(Queue<Person> pQueue)
        {
            int k = 0;
            foreach(var obj in pQueue)
            {
                Type a = obj.GetType();
                if (a.Equals(typeof(T)))
                    k++;
            }
            return k;
        }
        #endregion

        #region Query2region
        static public void Query2()
        {
            try
            {
                if (Tools.IsNullOrEmpty(queue))
                    throw new Exception("Невозможно исполнить запрос!");
                
                Console.WriteLine("Вывести элементы определённого типа");
            
                int k = Tools.ChooseType("Выберите тип: ");
                Console.Write("Элементы указанного типа: ");
                switch (k)
                {
                    case 1:
                        PrintQueueByTypes<Employee>();
                        break;
                    case 2:
                        PrintQueueByTypes<Engineer>();
                        break;
                    case 3:
                        PrintQueueByTypes<Administration>();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static private void PrintQueueByTypes<T>()
        {
            foreach (var person in queue)
            {
                Type a = person.GetType();
                if (a.Equals(typeof(T)))
                {
                    person.ShowInfo();
                }
            }
        }
        #endregion

        #region Query3region
        static public void Query3()
        {
            try
            {
                if (Tools.IsNullOrEmpty(queue))
                    throw new Exception("Невозможно исполнить запрос!");
                
                Console.WriteLine("Вывести кол-во Мужчин/Женщин/Неназванных каждого типа");

                Console.WriteLine(CountSexByTypes<Employee>());
                Console.WriteLine(CountSexByTypes<Engineer>());
                Console.WriteLine(CountSexByTypes<Administration>());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static private string CountSexByTypes<T>()
        {
            int m = 0;
            int w = 0;
            int na = 0;
            
            foreach (var person in queue)
            {
                Type a = person.GetType();
                if (a.Equals(typeof(T)))
                {
                    if (person.Sex == 'М')
                        m++;
                    else if (person.Sex == 'Ж')
                        w++;
                    else
                        na++;
                }
            }
            return $"Тип {typeof(T).ToString()}\nМужчин: {m}\nЖенщин: {w}\nНеизвестно: {na}";
        }
        #endregion

        static public void QueueCloning()
        {
            try
            {
                if (Tools.IsNullOrEmpty(queue))
                    throw new Exception("Клонированная коллекция недоступна для печати!");

                cQueue = new Queue<Person>(queue);
                
                Console.WriteLine("Основная коллекция:");
                PrintQueuePerson(queue);
                Console.WriteLine("Клонированная коллекция");
                PrintQueuePerson(cQueue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static public void SortQueue()
        {
            try
            {
                if (Tools.IsNullOrEmpty(queue))
                    throw new Exception("Невозможно отсортировать коллекцию!");
                Person[] persArr = new Person[queue.Count];

                for (int i = 0; i < persArr.Length; i++)
                {
                    persArr[i] = queue.Dequeue();
                }

                Array.Sort(persArr, new SortByName());

                Queue<Person> buffQueue = new Queue<Person>();
                
                for (int i = 0; i < persArr.Length; i++)
                {
                    buffQueue.Enqueue(persArr[i]);
                }

                queue = new Queue<Person>(buffQueue);
                
                PrintQueuePerson(queue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        static public void SearchQueue()
        {
            try
            {
                if (Tools.IsNullOrEmpty(queue))
                    throw new Exception("Невозможно отсортировать коллекцию!");

                Queue<Person> bufQueue = new Queue<Person>(queue);

                Person[] persArr = new Person[bufQueue.Count];
                
                for (int i = 0; i < persArr.Length; i++)
                {
                    persArr[i] = bufQueue.Dequeue();
                }
                string name = Tools.InputString("Имя для поиска: ");

                List<Person> perList = persArr.ToList();

                int index = SearchName(perList, new SortByName(), name);
                
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        private static int SearchName(List<Person> list, IComparer comparer, string name)
        {
            Tools.SortWithComparer(ref list, comparer);

            Person[] arr = list.ToArray();

            int index = Array.BinarySearch(arr,new Person(name, 1, 'М'), comparer);

            if(index > -1)
            {
                Console.WriteLine($"Номер в списке: {index + 1}");
                list[index].ShowInfo();
                return index;
            }
            else
            {
                Console.WriteLine("ФИО не найдено");
                return -1;
            }
        }
    }
}
