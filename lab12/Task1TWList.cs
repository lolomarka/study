using System;
using System.Collections.Generic;
using OOPlab10;
using OOPLAB11;

namespace L12
{
    public class Task1TWList
    {
        public static void PrintMenu()
        {
            Console.WriteLine("  ДВУНАПРВЛЕННЫЙ СПИСОК\n" +
                "1. Создать\n" +
                "2. Добавить элемент на указанную позицию (номер)\n" +
                "3. Печать\n" +
                "4. Удалить из памяти\n" +
                "44. Очистить консоль\n" +
                "55. Печать меню\n" +
                "0. Назад\n");
        }

        public static void RunMenu()
        {
            int step;
            PrintMenu();

            TWLinkedList<Person> list = null;

            do
            {
                step = Tools.InputNumInt();

                switch (step)
                {
                    case 1:
                        Create(out list, Tools.InputNumOfElements("Размер списка: "));
                        break;
                    case 2:
                        if (IsNull(list)) break;
                        AddAt(ref list, Tools.InputNumOfElements("Позиция [1..N]: "));
                        break;
                    case 3:
                        Print(list);
                        break;
                    case 4:
                        Clear(list);
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

        public static void Print(TWLinkedList<Person> list)
        {
            if (IsNull(list)) return;

            list.Print();
        }

        public static bool AddAt(ref TWLinkedList<Person> list, int pos)
        {

            Person p = Generator.CreateNewEmployee().Base;
            Console.Write("Сгенерирован: ");
            ColorPrint.Print(p.ToString() + '\n', ConsoleColor.Cyan);

            bool res = list.AddAt(p, pos);

            if (res)
                ColorPrint.Success("Элемент добавлен\n");

            return res;
        }

        public static void Clear(TWLinkedList<Person> list)
        {
            if (IsNull(list)) return;

            if (list.DeleteList())
                ColorPrint.Success("Список успешно удален\n");

        }

        public static void Create(out TWLinkedList<Person> list, int size)
        {
            List<Person> tmpList = new List<Person>();

            for (int i = 0; i < size; i++)
            {
                tmpList.Add(Generator.CreateNewEmployee().Base);
            }

            list = new TWLinkedList<Person>(tmpList);

            if (list.Size == size)
                ColorPrint.Success("Список успешно создан\n");
        }

        private static bool IsNull(object obj)
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

