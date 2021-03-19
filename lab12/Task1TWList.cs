using System;
using System.Collections.Generic;
using System.Linq;
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
                "2. Добавить элемент на 1,3,5... позицию (номер)\n" +
                "3. Печать\n" +
                "4. Удалить из памяти\n" +
                "44. Очистить консоль\n" +
                "55. Печать меню\n" +
                "0. Назад\n");
        }

        public static void RunMenu()
        {
            int step;
            

            TWLinkedList<Person> list = null;

            do
            {
                PrintMenu();
                step = Tools.InputNumInt();

                switch (step)
                {
                    case 1:
                        Create(out list, Tools.InputNumOfElements("Размер списка: "));
                        break;
                    case 2:
                        if (IsNull(list)) break;
                        AddOddElements(ref list);
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

        public static void AddOddElements(ref TWLinkedList<Person> list)
        {
            try
            {
                for (int i = 1; i <= list.Count(); i+=2)
                {
                    var p = Generator.CreateNewEmployee().Base;
                    p.Name = "Добавленный: " + p.Name;
                    list.AddAt(p, i);
                }
                var a = Generator.CreateNewEmployee().Base;
                a.Name = "Добавленный: " + a.Name;
                list.AddLast(a);
                
                ColorPrint.Success("Элементы добавлены\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
            
            
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

