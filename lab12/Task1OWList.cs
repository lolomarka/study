using System;
using System.Collections.Generic;
using OOPlab10;
using OOPLAB11;

namespace L12
{
    public class Task1OWList
    {
        public static void PrintMenu()
        {
            Console.WriteLine("  ОДНОНАПРВЛЕННЫЙ СПИСОК\n" +
                "1. Создать\n" +
                "2. Удалить элементы с четными инф. полями (по возрасту)\n" +
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

            OWLinkedList<Person> list = null;

            do
            {
                step = Tools.InputNumInt("> ");

                switch (step)
                {
                    case 1:
                        Create(out list, Tools.InputNumOfElements("Размер списка: "));
                        break;
                    case 2:
                        RemoveEvenData(ref list);
                        break;
                    case 3:
                        Print(list);
                        break;
                    case 4:
                        Clear(ref list);
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

        public static void Print(OWLinkedList<Person> list)
        {
            if (IsNull(list)) return;

            list.Print();
        }

        public static void Clear(ref OWLinkedList<Person> list)
        {
            if (IsNull(list)) return;

            if(list.DeleteList())
                ColorPrint.Success("Список успешно удален\n");

        }

        public static void Create(out OWLinkedList<Person> list, int size)
        {
            List<Person> tmpList = new List<Person>();

            for (int i = 0; i < size; i++)
            {
                tmpList.Add(Generator.CreateNewEmployee().Base);
            }

            list = new OWLinkedList<Person>(tmpList);

            if (list.Size == size)
                ColorPrint.Success("Список успешно создан\n");
        }

        public static int RemoveEvenData(ref OWLinkedList<Person> list)
        {
            if (IsNull(list)) return 0;

            int deleted = 0;

            foreach (Person item in list)
            {
                if (item.Age % 2 == 0)
                {
                    list.Remove(item);
                    deleted++;
                }    
            }

            ColorPrint.Success("Удалено элементов: ");
            Console.WriteLine(deleted);

            return deleted;
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

