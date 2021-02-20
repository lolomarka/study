using System;
using OOPlab10;
// ReSharper disable once RedundantUsingDirective


namespace OOPLAB11
{
    public class Menu
    {
        public static void PrintMenu(int type)
        {
            Console.Clear();

            switch(type)
            {
                case 0:
                    Console.WriteLine("\tЗадание");
                    Console.WriteLine("1. Задание 1");
                    Console.WriteLine("2. Задание 2");
                    Console.WriteLine("3. Задание 3");
                    break;
                case 1:
                    Console.WriteLine("\tЗадание 1\n\tQueue<T>");
                    Console.WriteLine("1. Создать новую коллекцию");
                    Console.WriteLine("2. Заполнить коллекцию случайно");
                    Console.WriteLine("3. Заполнить коллекцию вручную");
                    Console.WriteLine("4. Печать элементов в коллекции");
                    Console.WriteLine("5. Поместить элемент в начало");
                    Console.WriteLine("6. Извлечь последний элемент");
                    Console.WriteLine("7. Выполнить запрос №1");
                    Console.WriteLine("8. Выполнить запрос №2");
                    Console.WriteLine("9. Выполнить запрос №3");
                    Console.WriteLine("10. Клонировать коллекцию");
                    Console.WriteLine("11. Сортировать коллекцию");
                    Console.WriteLine("12. Поиск элемента в коллекции");
                    Console.WriteLine("13. Печать клонированной коллекции");
                    break;
                case 2:
                    Console.WriteLine("\tЗадание 2\nSortedDictionary<T,K>");
                    Console.WriteLine("1. Добавить элемент в коллекцию");
                    Console.WriteLine("2. Удалить элемент из коллекции");
                    Console.WriteLine("3. Печать элементов коллекции");
                    Console.WriteLine("4. Выполнить запрос №1");
                    Console.WriteLine("5. Выполнить запрос №2");
                    Console.WriteLine("6. Выполнить запрос №3");
                    Console.WriteLine("7. Клонировать коллекцию");
                    Console.WriteLine("8. Поиск по коллекции");
                    
                    break;
                case 3:
                    Console.WriteLine("\tЗадание 3\nQueue<TKey>\tQueue<string>\nSortedDictionary<TKey,TValue>\nSortedDictionary<string,TValue>");
                    Console.WriteLine("1. Создать коллекцию");
                    Console.WriteLine("2. Добавить элемент");
                    Console.WriteLine("3. Удалить элемент");
                    Console.WriteLine("4. Печать");
                    Console.WriteLine("5. Поиск первого");
                    Console.WriteLine("6. Поиск центрального");
                    Console.WriteLine("7. Поиск последнего");
                    Console.WriteLine("8. Поиск несущ.");
                    Console.WriteLine("44.Очистить консоль");
                    Console.WriteLine("55.Печать меню");
                    Console.WriteLine("0. Назад");
                    break;
                default:
                    Console.WriteLine("Ошибка!");
                    break;
                
            }

            
            Console.WriteLine("\n\n0. Назад");
        }
        
        public static void RunMenu()
        {
            int step;
            do
            {
                Console.Clear();
                PrintMenu(0);
                step = Tools.InputNumInt("> ", "Неверное число");
                switch (step)
                {
                    case 1:
                        Task1Menu();
                        PrintMenu(0);
                        break;
                    case 2:
                        Task2Menu();
                        PrintMenu(0);
                        break;
                    case 3:
                        Task3Menu();
                        PrintMenu(0);
                        break;
                    case 0:
                        break;
                    case 10:
                        PrintMenu(0);
                        break;
                    default:
                        Console.WriteLine("Неверный шаг");
                        break;
                }
                
            } while (step != 0); 
        }
        
        static void Task1Menu()
        {
            PrintMenu(1);
            int step;

            
            do
            {
                step = Tools.InputNumInt(">> ","Ошибка ввода");
                switch(step)
                {
                    case 1:
                        Program.CreateQueue();
                        break;
                    case 2:
                        try
                        {
                            Program.FillQueueRnd();
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1");
                            
                            
                        }
                        break;
                    case 3:
                        try
                        {
                            Program.FillQueueMan();
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1");
                            
                            
                        }
                        break;
                    case 4:
                        try
                        {
                            Program.PrintQueuePerson(Program.QueueProperty);
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1");
                            
                            
                        }
                        break;
                    case 5:
                        try
                        {
                            Program.EnqueueToQueue();
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1");
                            
                        }
                        break;
                    case 6:
                        try
                        {
                            Program.DequeueFromQueue();
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1");
                            
                        }
                        break;
                    case 7:
                        try
                        {
                            Program.Query1(); 
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1");
                            
                        }
                        break;
                    case 8:
                        try
                        {
                            Program.Query2(); 
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1");
                            
                        }
                        break;
                    case 9:
                        try
                        {
                            Program.Query3();
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1");
                            
                        }
                        break;
                    
                    case 10:
                        try
                        {
                            Program.QueueCloning();     
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1 или #10");
                            Tools.Wait();
                        }
                        break;
                    case 11:
                        try
                        {
                            Program.SortQueue(); 
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1");
                            Tools.Wait();
                        }
                        break;
                    case 12:
                        try
                        {
                            Program.SearchQueue(); 
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1");
                            Tools.Wait();
                        }
                        break;
                    
                    case 13:
                        try
                        {
                            Program.PrintQueuePerson(Program.CQueueProperty);
                        }
                        catch
                        {
                            Console.WriteLine("Возникло исключение, возможно очередь не инициализирована!\nОбратитесь к пункту меню #1 или #10");
                            Tools.Wait();
                        }
                        break;
                        
                    default:
                        return;
                }
                
                Tools.Wait();

                PrintMenu(1);
            }while(true);
        }
        
        static void Task2Menu()
        {
            PrintMenu(2);
            int step;

            
            do
            {
                step = Tools.InputNumInt(">> ","Ошибка ввода");
                switch(step)
                {
                    case 1:
                        Program.AddElementToDictionary(Program.MySortedDictionary);
                        break;
                    case 2:
                        try
                        {
                            if (Tools.IsNullOrEmpty(Program.MySortedDictionary))
                                throw new Exception("Коллекция или пуста, или не инициализированна.\nНечего удалять!");
                            Program.DeleteElementToDictionary(Program.MySortedDictionary);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                        break;
                    case 3:
                        try
                        {
                            if (Tools.IsNullOrEmpty(Program.MySortedDictionary))
                                throw new Exception("Коллекция или пуста, или не инициализированна.\nНечего выводить!");
                            Program.PrintSortedDictionary(Program.MySortedDictionary);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 4:
                        Program.SortedDictionaryQuery1();
                        break;
                    case 5:
                        Program.SortedDictionaryQuery2();
                        break;
                    case 6:
                        Program.SortedDictionaryQuery3();
                        break;
                    case 7:
                        Program.SortedDictionaryCloning();
                        break;
                    case 8:
                        Program.SearchInSortedDictionary();
                        break;
                    default:
                        return;
                }
                
                Tools.Wait();

                PrintMenu(2);
            }while(true);
        }

        static void Task3Menu()
        {
            int step;
            PrintMenu(3);

            TestCollections<Person, Employee> coll = null;

            do
            {
                
                step = Tools.InputNumInt("> ");
                
                switch (step)
                {
                    case 1:
                        Program.CreateColl(ref coll, Tools.InputNumOfElements("Размер коллекции: "));
                        break;

                    case 2:
                        Program.AddElem(ref coll);
                        break;

                    case 3:
                        Program.DelElem(ref coll);
                        break;

                    case 4:
                        if (coll != null) coll.PrintColl();
                        break;
                        
                    case 5:
                        Program.TestSearch(coll, 0);
                        break;

                    case 6:
                        if (coll != null) Program.TestSearch(coll, coll.Count / 2);
                        break;

                    case 7:
                        if (coll != null) Program.TestSearch(coll, coll.Count - 1);
                        break;

                    case 8:
                        Program.TestSearch(coll, -1);
                        break;


                    case 44:
                        Console.Clear();
                        PrintMenu(3);
                        break;
                    case 55:
                        PrintMenu(3);
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Неверный шаг");
                        break;

                }
                Tools.Wait();
                PrintMenu(3);
            } while (step != 0);
        }
    }
}