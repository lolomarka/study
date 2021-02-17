using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                    Console.WriteLine("2. Задание 2");
                    break;
                case 2://TODO: Заменить строчки
                    Console.WriteLine("\tЗадание 2\nSortedDictionary<T,K>");
                    Console.WriteLine("1. Добавить элемент в коллекцию");
                    Console.WriteLine("2. Удалить элемент из коллекции");
                    Console.WriteLine("3. Печать элементов коллекции");
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
                PrintMenu(2);
                step = 2;
                switch (step)
                {
                    case 2:
                        Task2Menu();
                        PrintMenu(2);
                        break;
                    case 0:
                        break;
                    case 10:
                        PrintMenu(2);
                        break;
                    default:
                        Console.WriteLine("Неверный шаг");
                        break;
                }
                
            } while (step != 0); 
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
                        Program.AddElementToDictionary(Program.MySortedDictionary);
                        break;
                    case 2:
                        Program.DeleteElementToDictionary(Program.MySortedDictionary);
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
                    default:
                        Environment.Exit(0);
                        return;
                }
                
                Tools.Wait();

                PrintMenu(2);
            }while(step != 0);
        }
        

        
        
    }
}