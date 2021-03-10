
using OOPlab10;
using OOPLAB11;
using System;
using System.Collections.Generic;
using System.Text;

namespace L12
{
    public class Task1Tree
    {
        public static void PrintMenu()
        {
            Console.WriteLine("  ИД. БАЛАНС. ДЕРЕВО\n" +
                "1. Создать\n" +
                "2. Поиск по ключу (фамилия)\n" +
                "3. Печать\n" +
                "4. Удалить из памяти\n" +
                "5. В дерево поиска\n" +
                "44. Очистить консоль\n" +
                "55. Печать меню\n" +
                "0. Назад\n");
        }

        public static void RunMenu()
        {
            int step;
            PrintMenu();

            Tree<Person> tree = null;

            do
            {
                step = Tools.InputNumInt("> ");

                switch (step)
                {
                    case 1:
                        Create(out tree, Tools.InputNumOfElements("Размер дерева: "));
                        break;
                    case 2:
                        if (IsNull(tree)) break;
                        Console.Write("Имя для поиска: ");
                        TreeSearch(tree, Console.ReadLine());
                        break;
                    case 3:
                        Print(tree);
                        break;
                    case 4:
                        Clear(tree);
                        break;

                    case 5:
                        if (IsNull(tree)) break;
                        tree.ToSearchTree();
                        break;

                    case 44:
                        Console.Clear();
                        PrintMenu();
                        break;
                    case 55:
                        PrintMenu();
                        break;

                    case 0:
                        break;
                    default:
                        Console.WriteLine("Неверный шаг");
                        break;
                }

            } while (step != 0);
        }

        public static void Print(Tree<Person> tree)
        {
            if (IsNull(tree)) return;

            tree.Print();
        }

        public static void Clear(Tree<Person> tree)
        {
            if (IsNull(tree)) return;

            if (tree.Clear())
                ColorPrint.Success("Дерево успешно удалено\n");

        }

        public static int TreeSearch(Tree<Person> tree, string surname)
        {
            if (IsNull(tree)) return 0;

            int count = tree.Search(surname);

            ColorPrint.Success("Кол-во совпадений по фамилии ");
            ColorPrint.Print(surname, ConsoleColor.Cyan);
            ColorPrint.Success(" = ");
            Console.WriteLine(count);

            return count;

        }

        public static void Create(out Tree<Person> tree, int size)
        {
            Stack<Person> stack = new Stack<Person>();

            for (int i = 0; i < size; i++)
            {
                Person p = Generator.CreateNewEmployee().Base;
                while (stack.Contains(p))
                {
                    p = Generator.CreateNewEmployee().Base;
                    ColorPrint.Print("Совпадение. Перегенерация.\n", ConsoleColor.DarkGray);
                }
                stack.Push(p);
            }

            //foreach (Person item in stack)
            //{
            //    item.Print();
            //}

            tree = new Tree<Person>(stack);

            if (tree.Size == size)
                ColorPrint.Success("Дерево успешно создано\n");
        }

        public static bool IsNull(object obj)
        {
            if (obj == null)
            {
                ColorPrint.Error("Под объект не выделена память\n");
                return true;
            }
            return false;
        }
    }
}
