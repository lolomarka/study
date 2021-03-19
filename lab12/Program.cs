using OOPLAB11;
using OOPlab10;
using System;

namespace L12
{
    class Program
    {
        static void Main()
        {
            RunMenu();
        }

        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1. 1Направленный Список\n" +
                              "2. 2Направленный Список\n" +
                              "3. Дерево\n" +
                              "4. Ид.Сб.Дерево\n" +
                              "0. Выход\n +");
        }

        public static void RunMenu()
        {
            int step;
            PrintMenu();

            do
            {
                step = Tools.InputNumInt("> ");

                switch (step)
                {
                    case 1:
                        Console.Clear();
                        Task1OWList.RunMenu();
                        PrintMenu();
                        break;
                    case 2:
                        Console.Clear();
                        Task1TWList.RunMenu();
                        PrintMenu();
                        break;
                    case 3:
                        Console.Clear();
                        Task1Tree.RunMenu();
                        PrintMenu();
                        break;
                    case 4:
                        Console.Clear();
                        Task2Tree.RunMenu();
                        PrintMenu();
                        break;
                    case 0:
                        break;
                    default:
                        ColorPrint.Error("Неверный шаг\n");
                        break;
                }

            } while (step != 0);
        }
    }
}