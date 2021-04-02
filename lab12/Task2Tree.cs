
using OOPlab10;
using OOPLAB11;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace L12
{
    public class Task2Tree
    {
        public static void PrintMenu()
        {
            Console.WriteLine(" Дерево\n" +
                "1. Создать пустое\n" +
                "2. Создать заполненное\n" +
                "3. Создать пустое с емкостью \n" +
                "4. Печать\n\n" +

                "5. Добавить элемент\n" +
                "6. Добавить несколько\n\n" +

                // "7. Удалить последний элемент\n" +
                // "8. Удалить элемент по номеру\n" +
                // "9. Удалить несколько (начало, конец)\n\n" +

                "10. Поиск по ФИО\n\n" +
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
            

            Tree<Person> tree = null;

            do
            {
                PrintMenu();
                step = Tools.InputNumInt("> ");

                switch (step)
                {
                    case 1:
                        CreateEmpty(out tree);
                        break;
                    case 2:
                        CreateSize(out tree, Tools.InputNumOfElements("Размер списка: "));
                        break;
                    case 3:
                        CreateCapacity(out tree, Tools.InputNumOfElements("Ёмкость списка: "));
                        break;
                    case 4:
                        Print(tree);
                        break;
                    case 5:
                        if (tree != null) tree.Insert(Generator.CreateRandomHuman());
                        ColorPrint.Success("Элемент добавлен \n");
                        break;

                    case 6:
                        if (IsNull(tree)) break;
                        if (tree != null)
                        {
                            tree.AddRange(PersonColl(Tools.InputNumOfElements("Кол-во элементов: ")));
                            ColorPrint.Success("Элементы добавлены \n");
                        }
                        else 
                            ColorPrint.Error("Ошибка\n");
             
                        
                        break;
                    
                    
                    case 13:
                        Clear(tree);
                        break;
                    
                    case 10:
                        Console.WriteLine("ФИО для поиска: ");
                        SearchName(tree, Console.ReadLine());
                        break;
                
                    case 11:
                        try
                        {
                            if (IsNull(tree)) break;
                            TestCopy(tree);
                        }
                        catch (Exception e)
                        {
                            ColorPrint.Error(e.Message);
                        }
                        break;
                    case 12:
                        try
                        {
                            if (IsNull(tree)) break;
                            TestClone(tree);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            
                        }
                        
                        break;
                    
                    // case 7:
                    //     if (IsNull(list)) break;
                    //     list.RemoveLast();
                    //     break;
                    //
                    // case 8:
                    //     if (IsNull(list)) break;
                    //     list.RemoveAt(Tools.InputNumOfElements("Позиция [1..N]: "));
                    //     break;
                    //
                    // case 9:
                    //     if (IsNull(list)) break;
                    //     list.RemoveRange(Tools.InputNumOfElements("Начальная позиция (вкл): "), Tools.InputNumOfElements("Конечная позиция позиция (вкл): "));
                    //     break;

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

        public static void TestCopy(Tree<Person> tree)
        {
            
            if (IsNull(tree)) return;
            Tree<Person> copy = tree.Copy();

            
            
            
            ColorPrint.Print("Копия: \n",ConsoleColor.White);
            copy.Print();
            
            copy.Root.Data.Name = "АААААААААА";
            
            ColorPrint.Print("Копия при изменении фамилии 1 элемента в первоначальном списке:",ConsoleColor.White);
            copy.Print();
            
        }
        
        // public static void TestCopy(LinkedListT2<Person> list)
        // {
        //     if (IsNull(list)) return;
        //     LinkedListT2<Person> copy = list.Copy();
        //
        //     ColorPrint.Print("Копия: \n", ConsoleColor.White);
        //     copy.Print();
        //
        //     list.Head.Data.Name = "AAAAAAAAA";
        //
        //     ColorPrint.Print("Копия при изменении фамилии 1 элемента в первоначальном списке: \n", ConsoleColor.White);
        //     copy.Print();
        // }
        // public static void TestClone(LinkedListT2<Person> list)
        // {
        //     if (IsNull(list)) return;
        //     LinkedListT2<Person> clone = list.Clone();
        //
        //     ColorPrint.Print("Клон: \n", ConsoleColor.White);
        //     clone.Print();
        //
        //     list.Head.Data.Name = "ББББББББББ";
        //
        //     ColorPrint.Print("Клон при изменении фамилии 1 элемента в первоначальном списке: \n", ConsoleColor.White);
        //     clone.Print();
        // }

        public static void TestClone(Tree<Person> tree)
        {
            if(IsNull(tree)) return;

            Tree<Person> clone =(Tree<Person>)tree.Clone();

            // #region 
            // string name = clone.Root.Data.Name;
            // #endregion
            ColorPrint.Print("Клон: \n",ConsoleColor.White);
            clone.Print();

            clone.Root.Data.Name = "БББББББББ";
            
            ColorPrint.Print("Клон при изменении фамилии 1 элемента в первоначальном списке: \n",ConsoleColor.White);
            clone.Print();

            // #region
            // clone.Root.Data.Name = name;
            // #endregion
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

        public static int SearchName(Tree<Person> tree, string name)
        {
            if (IsNull(tree)) return 0;

           
            int count = tree.Search(name);
            
            ColorPrint.Success($"Кол-во совпадений: {count}\n");
            
            return count;
        }

        public static void Print(LinkedListT2<Person> list)
        {
            if (IsNull(list)) return;

            list.Print();
            ColorPrint.Print("Capacity: " + list.Capacity + '\n', ConsoleColor.DarkMagenta);
            ColorPrint.Print("Count: " + list.Count + '\n', ConsoleColor.DarkMagenta);
        }
        public static void Print(Tree<Person> tree)
        {
            if (IsNull(tree)) return;

            tree.Print();
            
            if (IsNull(tree))
            {
                ColorPrint.Error("Список пустой.");    
            }

            ColorPrint.Print("Size: " + tree.Size + '\n', ConsoleColor.DarkMagenta);
            ColorPrint.Print("Capacity: " + tree.Capacity + '\n', ConsoleColor.DarkMagenta);
        }

        public static void Clear(LinkedListT2<Person> list)
        {
            if (IsNull(list)) return;

            if (list.Clear())
                ColorPrint.Success("Список успешно удален\n");

        }

        public static void Clear(Tree<Person> tree)
        {
            if (IsNull(tree)) return;
            
            if(tree.Clear())
                ColorPrint.Success("Дерево успешно удалено\n");
        }

        public static void CreateSize(out LinkedListT2<Person> list, int size)
        {
            list = new LinkedListT2<Person>(PersonColl(size));

            if (list.Count == size)
                ColorPrint.Success("Список успешно создан\n");
        }

        public static void CreateSize(out Tree<Person> tree, int size)
        {
            tree = new Tree<Person>(PersonColl(size));
            
            if(tree.Size == size)
                ColorPrint.Success("Дерево успешно создано");
        }

        public static void CreateCapacity(out LinkedListT2<Person> list, int capacity)
        {

            list = new LinkedListT2<Person>(capacity);

            if (list.Capacity == capacity)
                ColorPrint.Success("Список успешно создан\n");
        }

        public static void CreateCapacity(out Tree<Person> tree, int capacity)
        {
            tree = new Tree<Person>(capacity);
            
            if(tree.Size == capacity)
                ColorPrint.Success("Дерево успешно созданно");
        }

        public static void CreateEmpty(out LinkedListT2<Person> list)
        {

            list = new LinkedListT2<Person>();

            if (list.Count == 0 && list.Capacity == 0)
                ColorPrint.Success("Список успешно создан\n");
        }

        public static void CreateEmpty(out Tree<Person> tree)
        {
            tree = new Tree<Person>();

            if (tree.Size == 0 && tree.Height == 0)
                ColorPrint.Success("Дерево успешно создано\n");
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
