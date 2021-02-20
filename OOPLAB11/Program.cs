using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OOPlab10;
namespace OOPLAB11
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.RunMenu();
        }

        #region Task1

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
                Console.WriteLine(e.Message);
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
                Console.WriteLine(e.Message);
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

                Console.WriteLine(CountSexByTypes<Employee>(queue));
                Console.WriteLine(CountSexByTypes<Engineer>(queue));
                Console.WriteLine(CountSexByTypes<Administration>(queue));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static private string CountSexByTypes<T>(Queue<Person> pQueue)
        {
            int m = 0;
            int w = 0;
            int na = 0;
            
            foreach (var person in pQueue)
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
                Console.WriteLine(e.Message);
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
                Console.WriteLine(e.Message);
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

        #endregion
        
        #region Task2

        static private SortedDictionary<string, Person> mySortedDictionary = new SortedDictionary<string, Person>();

        public static SortedDictionary<string, Person> MySortedDictionary
        {
            get => mySortedDictionary;
            set => mySortedDictionary = value;
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

        #region sdQuery1
        static public void SortedDictionaryQuery1()
        {
            try
            {
                if (Tools.IsNullOrEmpty(mySortedDictionary))
                    throw new Exception("Невозможно исполнить запрос!");
                Console.WriteLine("Вывести кол-во элементов определённого типа");

                int k = Tools.ChooseType();
                Console.Write("Кол-во элементов заданного типа: ");
                switch (k)
                {
                    case 1:
                        Console.WriteLine(CountTypes<Employee>(MySortedDictionary));
                        break;
                    case 2:
                        Console.WriteLine(CountTypes<Engineer>(MySortedDictionary));
                        break;
                    case 3:
                        Console.WriteLine(CountTypes<Administration>(MySortedDictionary));
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        static private int CountTypes<T>(SortedDictionary<string,Person> pSortedDictionary)
        {
            int k = 0;

            foreach (var VARIABLE in pSortedDictionary)
            {
                Type a = VARIABLE.Value.GetType();
                if (a.Equals(typeof(T)))
                    k++;
            }
            return k;
        }
        #endregion


        #region sdQuery2
        
        static public void SortedDictionaryQuery2()
        {
            try
            {
                if (Tools.IsNullOrEmpty(mySortedDictionary))
                    throw new Exception("Невозможно исполнить запрос!");
                Console.WriteLine("Вывести элементы определённого типа");

                int k = Tools.ChooseType();
                Console.WriteLine("Элементы заданного типа\nКЛЮЧ\n-----------\nЗНАЧЕНИЕ:\n");
                switch (k)
                {
                    case 1:
                        PrintSDictByTypes<Employee>(MySortedDictionary);
                        break;
                    case 2:
                        PrintSDictByTypes<Engineer>(MySortedDictionary);
                        break;
                    case 3:
                        PrintSDictByTypes<Administration>(MySortedDictionary);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        
        static private void PrintSDictByTypes<T>(SortedDictionary<string,Person> pSortedDictionary)
        {
            foreach (var VARIABLE in pSortedDictionary)
            {
                Type a = VARIABLE.Value.GetType();
                if (a.Equals(typeof(T)))
                {
                    Console.WriteLine(VARIABLE.Key);
                    Console.WriteLine("-----------");
                    VARIABLE.Value.ShowInfo();
                }
            }
        }
        
        

        #endregion


        #region sdQuery3

        static public void SortedDictionaryQuery3()
        {
            try
            {
                if (Tools.IsNullOrEmpty(MySortedDictionary))
                    throw new Exception("Невозможно исполнить запрос!");
                
                Console.WriteLine("Вывести кол-во Мужчин/Женщин/Неназванных каждого типа");

                Console.WriteLine(CountSexByTypes<Employee>(MySortedDictionary));
                Console.WriteLine(CountSexByTypes<Engineer>(MySortedDictionary));
                Console.WriteLine(CountSexByTypes<Administration>(MySortedDictionary));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static private string CountSexByTypes<T>(SortedDictionary<string, Person> pSortedDictionary)
        {
            int m = 0;
            int w = 0;
            int na = 0;

            foreach (var VARIABLE in pSortedDictionary)
            {
                Type a = VARIABLE.Value.GetType();
                if (a.Equals(typeof(T)))
                {
                    if (VARIABLE.Value.Sex == 'М')
                        m++;
                    else if (VARIABLE.Value.Sex == 'Ж')
                        w++;
                    else
                        na++;
                }
            }
            
            return $"Тип {typeof(T).ToString()}\nМужчин: {m}\nЖенщин: {w}\nНеизвестно: {na}";
        }

        #endregion


        public static void SortedDictionaryCloning()
        {
            try
            {
                if (Tools.IsNullOrEmpty(MySortedDictionary))
                    throw new Exception("Коллекция пуста, нечего клоннировать!");

                SortedDictionary<string,Person> сSortedDict = new SortedDictionary<string, Person>(MySortedDictionary);
                
                Console.WriteLine("Основная коллекция:");
                PrintSortedDictionary(MySortedDictionary);
                Console.WriteLine("Клонированная коллекция");
                PrintSortedDictionary(сSortedDict);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static void SearchInSortedDictionary()
        {
            try
            {
                if (Tools.IsNullOrEmpty(MySortedDictionary))
                    throw new Exception("Коллекция пуста или неинициализированна, невозможно выполнить поиск!");

                SortedDictionary<string, Person> buffSDict = new SortedDictionary<string, Person>(MySortedDictionary);

                string name = Tools.InputString("Введите ключ - имя элемента коллекции: ");

                if (buffSDict.ContainsKey(name))
                {
                    Console.WriteLine($"Элемент с заданным ключом найден. Его номер в словаре: {IndexOfName(buffSDict,name) + 1}");
                    buffSDict[name].ShowInfo();
                }
                else
                {
                    Console.WriteLine("Элемента с заданным ключом не обнаруженно");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int IndexOfName(SortedDictionary<string, Person> pSortedDictionary, string name)
        {
            int index = 0;
            foreach (var VARIABLE in pSortedDictionary)
            {
                if (Equals(VARIABLE.Key, name))
                    return index;
                index++;
            }

            return -1;
        }
        
        #endregion

        #region Task3

        public static void CreateColl(ref TestCollections<Person, Employee> coll, int size)
        {
            Queue<Employee> valsQueue = new Queue<Employee>();
            Queue<Person> keysQueue = new Queue<Person>();

            for (int i = 0; i < size; i++)
            {
                Employee emp = Generator.CreateNewEmployee();
                Person p = emp.Base;

                while (keysQueue.Contains(p))
                {
                    emp = Generator.CreateNewEmployee();
                    p = emp.Base;
                }
                
                valsQueue.Enqueue(emp);
                keysQueue.Enqueue(p);
            }

            coll = new TestCollections<Person, Employee>(valsQueue, keysQueue);
        }

        public static void AddElem(ref TestCollections<Person,Employee> coll)
        {
            if (IsNull(coll)) return;

            Employee emp = Generator.CreateNewEmployee();

            coll.Add(emp.Base, emp);
        }

        public static void DelElem(ref TestCollections<Person, Employee> coll)
        {
            if (IsNull(coll)) return;
            Person p = Generator.CreateNewEmployee().Base;              //Функция не была написана изначально. (Костыль)
            coll.Remove(p);
        }

        private static bool IsNull(TestCollections<Person, Employee> coll)
        {
            if (coll == null)
            {
                Console.WriteLine("Коллекция не создана");
                return true;
            }

            return false;
        }

        public static bool TestSearch(TestCollections<Person, Employee> coll, int index)
        {
            if (IsNull(coll)) return false;

            string element;

            Queue<Person> keys = /*(Queue<Person>)*/ coll.Keys;
            Queue<Employee> values = /*(Queue<Employee>)*/ coll.Values;
            Queue<string> strings = /*(Queue<string>)*/ coll.Strings;

            Person p = null, pNew;
            Employee emp = null, empNew;
            string str = null, strNew;

            if (index > -1)
            {
                // Индекс Person
                int pIndex = 0;
                foreach (Person pItem in keys)
                {
                    if (pIndex == index)
                        p = pItem;
                    else
                    {
                        pIndex++;
                    }
                }
                // Индекс Employee
                int empIndex = 0;
                foreach (Employee empItem in values)
                {
                    if (empIndex == index)
                        emp = empItem;
                    else
                    {
                        empIndex++;
                    }
                }
                // Индекс string
                int strIndex = 0;
                foreach (string strItem in strings)
                {
                    if (strIndex == index)
                        str = strItem;
                    else
                    {
                        strIndex++;
                    }
                }

                pNew = new Person(p.Name, p.Age, p.Sex);
                empNew = new Employee(emp.Name, emp.Age, emp.Sex, emp.Position);
                strNew = new string(str);
            }
            else
            {
                p = keys.Peek();
                emp = values.Peek();
                str = strings.Peek();

                pNew = new Person(p.Name + "1", p.Age, p.Sex);
                empNew = new Employee(emp.Name + "1", emp.Age, emp.Sex, emp.Position);
                strNew = new string(str + "1");
            }

            if (index == 0)
                element = "ПЕРВЫЙ";
            else if (index == coll.Count - 1)
                element = "ПОСЛЕДНИЙ";
            else if (index == coll.Count / 2)
                element = "ЦЕНТРАЛЬНЫЙ";
            else
                element = "НЕСУЩЕСТВУЮЩИЙ";

            Console.WriteLine(element + ":\n");

            bool isKeyInQueue = coll.SearchQueue(pNew);
            Console.WriteLine("TKeyQueue - Найден: " + isKeyInQueue + "\n");
            
            bool isStrInQueue = coll.SearchQueue(strNew);
            Console.WriteLine("StringQueue - Найден: " + isStrInQueue + "\n");
            
            bool isKeyInDict = coll.SearchDictKey(pNew);
            Console.WriteLine("TKeyDict - Найден: " + isKeyInDict + "\n");

            bool isStrInDict = coll.SearchDictKey(strNew);
            Console.WriteLine("StrDict - Найден: " + isStrInDict + "\n");

            bool isValueInDict = coll.SearchDictValue(empNew);
            Console.WriteLine("ValueDict - Найден: " + isValueInDict + "\n");

            return true;

        }
        
        #endregion

       
    }
}
