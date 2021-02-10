using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OOPlab10;

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
                case 2://TODO: Заменить строчки
                    Console.WriteLine("\tЗадание 2");
                    Console.WriteLine("1. Демонстрация перегрузки инкременты и декременты");
                    Console.WriteLine("2. Демонстрация перегрузки преобразования типов");
                    Console.WriteLine("3. Демонстрация перегрузки операторов сравнения");
                    break;
                case 3://TODO: Заменить строчки
                    Console.WriteLine("\tЗадание 3");
                    Console.WriteLine("1. Создать массив");
                    Console.WriteLine("2. Печать массива");
                    Console.WriteLine("3. Вывести элемент с наименьшей площадью");
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
            }while(step != 0);
        }

        static void Task2Menu()//TODO: Доделать, чтобы работало с визуальной частью из PrintMenu(2)
        {
            PrintMenu(2);
            int step;

            
            do
            {
                step = Tools.InputNumInt(">> ","Ошибка ввода");
                switch(step)
                {
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    default:
                        return;
                }

                PrintMenu(2);
            }while(step != 0);
        }
        

        static void Task3Menu()//TODO: Доделать, чтобы работало с визуальной частью из PrintMenu(3)
        {
            PrintMenu(3);
            int step;
            
            do
            {
                GC.Collect();
                step = Tools.InputNumInt(">> ", "Ошибка ввода");

                switch (step)
                {
                    case 1:
                    
                    break;
                    case 2:
                    
                    break;
                    case 3:
                    
                    break;
                    default:
                    return;
                }
                PrintMenu(3);
            } while (step != 0);
        }
        
    }
}