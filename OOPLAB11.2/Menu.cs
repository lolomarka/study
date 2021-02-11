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
                    Console.WriteLine("2. Задание 2");
                    break;
                case 2://TODO: Заменить строчки
                    Console.WriteLine("\tЗадание 2");
                    Console.WriteLine("1. Демонстрация перегрузки инкременты и декременты");
                    Console.WriteLine("2. Демонстрация перегрузки преобразования типов");
                    Console.WriteLine("3. Демонстрация перегрузки операторов сравнения");
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
                    case 2:
                        Task2Menu();
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
        

        
        
    }
}