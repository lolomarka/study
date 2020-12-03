using System;
namespace OOPlab9
{
    class Program
    {
        static public Random rndGen = new Random(0);
        

        
        /// 
        /// Вспомогательные функции
        /// 

        public Tools tool = new Tools();

        // static public int InputNumOfElements(string invMsg = "",string errMsg = "Ошибка: введите неотрицательное число")
        // {
        //     Console.Clear();
        //     Console.WriteLine(invMsg);
        //     int a;
        //     do
        //     {
                
        //         a = InputNumInt("","Введите целое число больше 0");
        //         if(a < 1)
        //             Console.WriteLine(errMsg+"\nПовторите ввод: ");
        //     }while(a < 1);

        //     return a;
        // }

        // static public double InputNumDouble(string invMsg = "", string errMsg ="")//Ввод целового числа
        // {
        //     Console.Write(invMsg);
        //     while(true)
        //     {
        //         double result;
        //         if(double.TryParse(Console.ReadLine(),out result))
        //             return result;
        //         Console.WriteLine(errMsg);
        //         Console.Write(invMsg);
        //     }
        // }

        // static public double InputAbsNumDouble(string invMsg = "", string errMsg = "Ошибка! Введено неверное число")
        // {
        //     double result;

        //     do
        //     {
        //         try
        //         {
        //             result = InputNumDouble(invMsg,errMsg);
        //             if (result < 0)
        //                 throw new Exception("Ожидалось положительное вещественное число!");
        //             return result;
        //         }
        //         catch(Exception err)
        //         {
        //             Console.WriteLine("Ошибка! "+ err.Message);
        //             Console.ReadKey();
        //             return 0;
        //         }
        //     }while(result < 0);
        // }

        // static public int InputNumInt(string invMsg = "", string errMsg ="Ошибка! Введено неверное число")//Ввод целового числа
        // {
        //     Console.Write(invMsg);
        //     while(true)
        //     {
        //         int result;
        //         if(int.TryParse(Console.ReadLine(),out result))
        //             return result;
        //         Console.WriteLine(errMsg);
        //         Console.Write(invMsg);
        //     }
        // }

        
        //////////////////////////////////
     
        static void Main(string[] args)
        {
            RunMenu();
        }

        static void RunMenu()
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
                rndGen.Next(-256,255);
            } while (step != 0); 
        }

        static void PrintMenu(int type)
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
                    Console.WriteLine("\tЗадание 1");
                    Console.WriteLine("1. Запустить пример для задания");
                    Console.WriteLine("2. Обнулить счётчик экземпляров");
                    break;
                case 2:
                    Console.WriteLine("\tЗадание 2");
                    Console.WriteLine("1. Демонстрация перегрузки инкременты и декременты");
                    Console.WriteLine("2. Демонстрация перегрузки преобразования типов");
                    Console.WriteLine("3. Демонстрация перегрузки операторов сравнения");
                    break;
                case 3:
                    Console.WriteLine("\tЗадание 3");
                    Console.WriteLine("1. Создать массив");
                    Console.WriteLine("2. Печать массива");
                    Console.WriteLine("3. Вывести элемент с наименьшей площадью");
                    break;
                default:
                    Console.WriteLine("Ошибка!");
                    break;
                
            }
            
            rndGen.Next(-256,255);
            Console.WriteLine("\n10. Очистка консоли");
            Console.WriteLine("0. Назад");
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
                        Example1();
                        break;
                    case 2:
                        EraseExample();
                        break;
                    default:
                        return;
                }

                PrintMenu(1);
            }while(step != 0);
        }

        static void Task2Menu()
        {
            PrintMenu(2);
            int step;

            
            do
            {
                step = Tools.InputNumInt(">> ","Ошибка ввода");
                switch(step)
                {
                    case 1:
                        ExampleIncDec();
                        break;
                    case 2:
                        ExampleConverting();
                        break;
                    case 3:
                        ExampleComparison();
                        break;
                    default:
                        return;
                }

                PrintMenu(2);
            }while(step != 0);
        }
        

        static void Task3Menu()
        {
            PrintMenu(3);
            int step;
            TriangleArray triArr = null;
            do
            {
                GC.Collect();
                step = Tools.InputNumInt(">> ", "Ошибка ввода");

                switch (step)
                {
                    case 1:
                    triArr = CreateTriangleArr();
                    break;
                    case 2:
                    PrintTriangleArr(triArr);
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
                    case 3:
                    PrintMinimalTriangleFromArray(triArr);
                    Console.ReadKey();
                    break;
                    default:
                    return;
                }
                PrintMenu(3);
            } while (step != 0);
        }
        

        static void Example1()
        {
            Console.WriteLine("Создаём первый экземпляр класса");
            Triangle tri = new Triangle();
            Console.WriteLine(tri.GetInformationToString);
            Console.WriteLine("Создаём ещё 2 экземпляра класса...");
            Triangle itr = new Triangle(1,2,3);
            Triangle rit = new Triangle(3.5,6.5,10.2);
            Console.WriteLine(itr.GetInformationToString);
            Console.WriteLine(rit.GetInformationToString);


            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey();
        }

        static void EraseExample()
        {
            GC.Collect();

            Console.WriteLine("Количество созданных эксемпляров обнулено");
            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey();
        }

        static void ExampleIncDec()
        {
            Triangle tri = new Triangle();
            int step;
            do
            {
                Console.Clear();
                Console.WriteLine("\tПример перегрузки №1");
                Console.WriteLine("1. Инкремент");
                Console.WriteLine("2. Декремент");
                Console.WriteLine("3. Вывести информацию об Треугольнике");
                Console.WriteLine("\n\n0. Назад");

                step = Tools.InputNumInt(">>> ","Ошибка ввода");

                switch(step)
                {
                    case 1:
                        tri++;
                        Console.WriteLine("Изменение было совершено.\nИнформацию вы можете увидеть выполнив 3й пункт меню.\nНажмите любую кнопку для продолжения...");
                        Console.ReadKey();
                        break;
                    case 2:
                        if(tri.A == 0 && tri.B == 0 && tri.C == 0)
                            {
                                tri--;
                                Console.WriteLine("Изменение не было совершено совершено.\nИнформацию вы можете увидеть выполнив 3й пункт меню.\nНажмите любую кнопку для продолжения...");
                            }
                        else
                        {
                            tri--;
                            Console.WriteLine("Изменение было совершено.\nИнформацию вы можете увидеть выполнив 3й пункт меню.\nНажмите любую кнопку для продолжения...");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine(tri.GetInformationToString);
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }


            } while (step != 0);
            GC.Collect();
        }

        static void ExampleConverting()
        {
            Triangle tri = new Triangle(5,5,5);
            int step;
            do
            {
                Console.Clear();
                Console.WriteLine("\tПример перегрузки №2");
                Console.WriteLine("1. Явное преобразование");
                Console.WriteLine("2. Неявное преобразование");
                Console.WriteLine("\n\n0. Назад");

                step = Tools.InputNumInt(">>> ","Ошибка ввода");
                Console.Clear();
                switch(step)
                {
                    case 1:
                        Console.WriteLine($"\tПреобразование (double)tri\nПлощадь треугольника = {(double)tri}\nСтороны:\nA = 5;\nB = 5;\nC = 5.");
                        break;
                    case 2:
                        Console.WriteLine($"\tПреобразование (bool) new Triangle(5,5,5)\nСуществования треугольника со сторонами:\nA = 5;\nB = 5;\nC = 5.\nРавна: {(bool)new Triangle(5,5,5)}");
                        Console.WriteLine($"\tПреобразование (bool) new Triangle(1,2,0)\nСуществования треугольника со сторонами:\nA = 1;\nB = 2;\nC = 0.\nРавна: {(bool)new Triangle(1,2,0)}");
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
            } while (step != 0);
            GC.Collect();
        }

        static void ExampleComparison()
        {
            Triangle t1 = new Triangle(2,5,4);
            Triangle t2 = new Triangle(3,4,5);
            int step;
            do
            {
                Console.Clear();
                Console.WriteLine("\tПример перегрузки №3");
                Console.WriteLine("1. T1 >= T2");
                Console.WriteLine("2. T1 <= T2");
                Console.WriteLine("\n\n0. Назад");

                step = Tools.InputNumInt(">>> ","Ошибка ввода");

                switch(step)
                {
                    case 1:
                        Console.WriteLine(t1.GetInformationToString);
                        Console.WriteLine(t2.GetInformationToString);
                        Console.WriteLine($"T1 >= T2: {t1 >= t2}");
                        break;
                    case 2:
                        Console.WriteLine(t1.GetInformationToString + "\n");
                        Console.WriteLine(t2.GetInformationToString + "\n");
                        Console.WriteLine($"T1 <= T2: {t1 <= t2}");
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
            } while (step != 0);
            GC.Collect();
        }

        static TriangleArray CreateTriangleArr()
        {
            TriangleArray tri = null;

            
            int step;

            
            do
            {
                Console.Clear();
                Console.WriteLine("\tСоздание массива: ");
                Console.WriteLine("1. Конструктор без параметров");
                Console.WriteLine("2. Конструктор с параметрами: Использовать ДСЧ");
                Console.WriteLine("3. Конструктор с параметрами: Ручной ввод");

                rndGen.Next(-256,255);
                Console.WriteLine("\n10. Очистка консоли");
                Console.WriteLine("0. Назад");

                step = Tools.InputNumInt(">>> ", "Ошибка ввода");

                switch (step)
                {
                    case 1:
                        tri = InitArrayEmpty();
                        Console.WriteLine("Был инициализирован пустой массив.");
                        Console.ReadKey();
                        break;
                    case 2:
                        tri = InitArrayRnd();
                        Console.WriteLine("Массив инициализирован при помощи ДСЧ");
                        Console.WriteLine("Вы можете посмотреть на результат,\nВыбрав соответствующий пункт в меню(Печать массива).");
                        Console.ReadKey();
                        break;
                    case 3:
                        tri = InitArrayMan();
                        Console.WriteLine("Массив инициализирован при помощи ручного ввода.");
                        Console.WriteLine("Вы можете посмотреть на результат,\nВыбрав соответствующий пункт в меню(Печать массива).");
                        Console.ReadKey();
                        break;
                    default:
                    break;
                }
            } while (step != 0);
            GC.Collect();
            return tri;
        }

        static void PrintTriangleArr(TriangleArray triArr)
        {
            try
            {
                if(triArr == null)
                {
                    throw new Exception("Массив не инициализирован");
                }
                else if(triArr.length == 0)
                {
                    Console.WriteLine("Массив пустой. Выводить нечего!");
                }
                else
                {
                    Console.WriteLine(triArr.Show());
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("Ошибка! "+ err.Message);
                Console.ReadKey();
            }
        }

        static TriangleArray InitArrayEmpty() 
        {
            return new TriangleArray();
        }

        static TriangleArray InitArrayRnd()
        {
            int length = Tools.InputNumOfElements("Введите длину массива: ","Ошибка: введите неотрицательное число");
            return new TriangleArray(length, rndGen);
        }

        static TriangleArray InitArrayMan()
        {
            int length = Tools.InputNumOfElements("Введите длину массива: ");
            return new TriangleArray(length);
        }

        static void PrintMinimalTriangleFromArray(TriangleArray triArr)
        {
            try
            {
                if(triArr == null || triArr.length == 0)
                {
                    throw new Exception("Массив или пуст или неинициализирован!");
                }

                Console.WriteLine("Номер элемента с наименьшей площадью: " + (int)(triArr.GetMinimalTriangle()+ 1));
                Console.WriteLine($"Информация об элементе: \n" + triArr[triArr.GetMinimalTriangle()].GetInformationToString);
            }
            catch(Exception err)
            {
                Console.WriteLine("Ошибка! " + err.Message);
            }
        }
    }
}
