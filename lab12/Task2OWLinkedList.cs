
using OOPlab10;
using OOPLAB11;
using System;
using System.Collections.Generic;
using System.Text;

namespace L12
{
    public class Task2OWLinkedList
    {
        public static void PrintMenu()
        {
            Console.WriteLine("  ОДНОНАПРВЛЕННЫЙ СПИСОК\n" +
                "1. Создать пустой\n" +
                "2. Создать заполненный\n" +
                "3. Создать пустой с емкостью \n" +
                "4. Печать\n\n" +

                "5. Добавить элемент в конец\n" +
                "6. Добавить несколько в конец\n\n" +

                "7. Удалить последний элемент\n" +
                "8. Удалить элемент по номеру\n" +
                "9. Удалить несколько (начало, конец)\n\n" +

                "10. Поиск по фамилии\n\n" +
                "11. Тест копирования\n" +
                "12. Тест клонирования\n" +

                "13. Удалить из памяти\n\n" +
                "44. Очистить консоль\n" +
                "55. Печать меню\n" +
                "0. Назад\n");
        }

        public static void RunMenu()
        {
            int step;
            PrintMenu();

            LinkedListT2<Person> list = null;

            do
            {
                step = Tools.InputNumInt("> ");

                switch (step)
                {
                    case 1:
                        CreateEmpty(out list);
                        break;
                    case 2:
                        CreateSize(out list, Tools.InputNumOfElements("Размер списка: "));
                        break;
                    case 3:
                        CreateCapacity(out list, Tools.InputNumOfElements("Ёмкость списка: "));
                        break;
                    case 4:
                        Print(list);
                        break;
                    case 5:
                        if (IsNull(list)) break;
                        list.AddLast(Generator.CreateNewEmployee().Base);
                        ColorPrint.Success("Элемент добавлен \n");
                        break;

                    case 6:
                        if (IsNull(list)) break;
                        list.AddRange(PersonColl(Tools.InputNumOfElements("Кол-во элементов: ")));
                        ColorPrint.Success("Элементы добавлены \n");
                        break;


                    case 13:
                        Clear(list);
                        break;

                    case 10:
                        Console.WriteLine("Фамилия для поиска: ");
                        SearchSurname(list, Console.ReadLine());
                        break;

                    case 11:
                        if (IsNull(list)) break;
                        TestCopy(list);
                        break;

                    case 12:
                        if (IsNull(list)) break;
                        TestClone(list);
                        break;

                    case 7:
                        if (IsNull(list)) break;
                        list.RemoveLast();
                        break;

                    case 8:
                        if (IsNull(list)) break;
                        list.RemoveAt(Tools.InputNumOfElements("Позиция [1..N]: "));
                        break;

                    case 9:
                        if (IsNull(list)) break;
                        list.RemoveRange(Tools.InputNumOfElements("Начальная позиция (вкл): "), Tools.InputNumOfElements("Конечная позиция позиция (вкл): "));
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

        public static void TestCopy(LinkedListT2<Person> list)
        {
            if (IsNull(list)) return;
            LinkedListT2<Person> copy = list.Copy();

            ColorPrint.Print("Копия: \n", ConsoleColor.White);
            copy.Print();

            list.Head.Data.Name = "AAAAAAAAA";

            ColorPrint.Print("Копия при изменении фамилии 1 элемента в первоначальном списке: \n", ConsoleColor.White);
            copy.Print();
        }
        public static void TestClone(LinkedListT2<Person> list)
        {
            if (IsNull(list)) return;
            LinkedListT2<Person> clone = list.Clone();

            ColorPrint.Print("Клон: \n", ConsoleColor.White);
            clone.Print();

            list.Head.Data.Name = "ББББББББББ";

            ColorPrint.Print("Клон при изменении фамилии 1 элемента в первоначальном списке: \n", ConsoleColor.White);
            clone.Print();
        }

        public static int SearchSurname(LinkedListT2<Person> list, string surname)
        {
            if (IsNull(list)) return 0;

            string output = "Результаты: ";
            int count = list.Search(surname, ref output);

            ColorPrint.Success($"Кол-во совпадений: {count}\n");
            if (count != 0)
                ColorPrint.Print(output + "\n", ConsoleColor.Cyan);
            return count;
        }

        public static void Print(LinkedListT2<Person> list)
        {
            if (IsNull(list)) return;

            list.Print();
            ColorPrint.Print("Capacity: " + list.Capacity + '\n', ConsoleColor.DarkMagenta);
            ColorPrint.Print("Count: " + list.Count + '\n', ConsoleColor.DarkMagenta);
        }

        public static void Clear(LinkedListT2<Person> list)
        {
            if (IsNull(list)) return;

            if (list.Clear())
                ColorPrint.Success("Список успешно удален\n");

        }

        public static void CreateSize(out LinkedListT2<Person> list, int size)
        {
            list = new LinkedListT2<Person>(PersonColl(size));

            if (list.Count == size)
                ColorPrint.Success("Список успешно создан\n");
        }

        public static void CreateCapacity(out LinkedListT2<Person> list, int capacity)
        {

            list = new LinkedListT2<Person>(capacity);

            if (list.Capacity == capacity)
                ColorPrint.Success("Список успешно создан\n");
        }

        public static void CreateEmpty(out LinkedListT2<Person> list)
        {

            list = new LinkedListT2<Person>();

            if (list.Count == 0 && list.Capacity == 0)
                ColorPrint.Success("Список успешно создан\n");
        }

        public static ICollection<Person> PersonColl(int size)
        {
            ICollection<Person> c = new List<Person>();

            for (int i = 0; i < size; i++)
            {
                c.Add(Generator.CreateNewEmployee().Base);
            }

            return c;
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
