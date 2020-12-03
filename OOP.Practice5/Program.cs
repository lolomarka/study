using System;

namespace OOP.Practice5
{
    class Program
    {
        //Статические переменные
        static int rndSeed = new DateTime().Millisecond;
        static void Main(string[] args)
        {
            RunMenu();
        }
        //Функции Меню
        static void RunMenu()
        {
             int step;

            

            do
            {
                Console.Clear();
                PrintMenu(0);
                step = InputNumInt("> ", "Неверное число");
                switch (step)
                {
                    case 1:
                    OneDimArrMenu();
                    PrintMenu(0);
                    break;
                    case 2:
                    TwoDimArrMenu();
                    PrintMenu(0);
                    break;
                    case 3:
                    JagArrMenu();
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
        static void PrintMenu(int type)
        {
            Console.Clear();
            switch(type)
            {
                case 0:
                Console.WriteLine("1. Одномерный массив");
                Console.WriteLine("2. Двумерный массив");
                Console.WriteLine("3. Рваный массив");
                break;
                case 1:
                Console.WriteLine("\tОдномерный массив");
                Console.WriteLine("1. Создать массив");
                Console.WriteLine("2. Печать массива");
                Console.WriteLine("3. Добавить элемент с номером K");
                break;
                case 2:
                Console.WriteLine("\tДвумерный массив");
                Console.WriteLine("1. Создать массив");
                Console.WriteLine("2. Печать массива");
                Console.WriteLine("3. Удалить строку, в которой находится наибольший элемент матрицы");
                break;
                case 3:
                Console.WriteLine("\tРваный массив");
                Console.WriteLine("1. Создать массив");
                Console.WriteLine("2. Печать массива");
                Console.WriteLine("3. Добавить строку в начало массива");
                break;
            }
            Console.WriteLine("\n10. Очистка консоли");
            Console.WriteLine("0. Назад");
        }


        static void OneDimArrMenu()
        {
            PrintMenu(1);
            
            int[] arri = null;
            double[] arrd = null;
            
            int step;
            bool solution;

            do
            {
                step = InputNumInt(">>","Ошибка ввода");
                switch(step)
                {
                    case 1:
                    solution = MakeChoice("Массив int","Массив double");
                    if(solution)
                    {
                        arrd = MakeArr_double(InputNumOfElements());
                    }
                    else
                    {
                        arri = MakeArr_int(InputNumOfElements());
                    }
                    Console.WriteLine("Инициализация массива окончена");
                    Console.ReadKey();
                    break;

                    case 2:
                    if(arri != null && arrd != null)
                    {
                        PrintArray(arri);
                        PrintArray(arrd);
                        Console.ReadKey();
                    }
                    else if(arri != null)
                    {
                        PrintArray(arri);
                        Console.WriteLine("Массив double не инициализирован");
                        Console.ReadKey();
                    }
                    else if(arrd != null)
                    {
                        Console.WriteLine("Массив int не инициализирован");
                        PrintArray(arrd);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Массив int не инициазирован");
                        Console.WriteLine("Массив double не инициализирован");
                        Console.ReadKey();
                    }
                    break;

                    case 3:
                    if(arrd == null && arri == null)
                    {
                        Console.WriteLine("Ни один из массивов не инициализирован");
                        Console.ReadKey();
                        break;
                    }
                    solution = MakeChoice("Добавить в массив int","Добавить в массив double");
                    if(solution)
                    {
                        if(arrd != null)
                            arrd = AddArrK(arrd);
                        else
                            {
                                Console.WriteLine("Перед тем, как добавить элемент в массив, его надо инициализировать");
                                Console.ReadKey();
                            }
                    }
                    else
                    {
                        if(arri != null)
                            arri = AddArrK(arri);
                        else
                            {
                                Console.WriteLine("Перед тем, как добавить элемент в массив, его надо инициализировать");
                                Console.ReadKey();
                            }
                    }
                    break;


                }
                PrintMenu(1);
            }while(step != 0);
        }


        static void TwoDimArrMenu()
        {
            PrintMenu(2);

            int[,] arri = null;
            double[,] arrd = null;

            int step;
            bool solution;
            
            do
            {
                step = InputNumInt(">> ", "Ошибка ввода");
                switch(step)
                {
                    case 1:
                    solution = MakeChoice("Массив int", "Массив double");
                    if(solution)
                    {
                        arrd = MakeArr_double(InputNumOfElements("Введите вертикальную длину: "),InputNumOfElements("Введите горизонтальную длину: "));
                    }
                    else
                    {
                        arri = MakeArr_int(InputNumOfElements("Введите вертикальную длину: "), InputNumOfElements("Введите горизонтальную длину: "));
                    }
                    Console.WriteLine("Инициализация массива завершена");
                    Console.ReadKey();
                    break;
                    case 2:
                    if(arri != null && arrd != null)
                    {
                        PrintArray(arri);
                        PrintArray(arrd);
                        Console.ReadKey();
                    }
                    else if(arri != null)
                    {
                        PrintArray(arri);
                        Console.WriteLine("Массив double не инициализирован");
                        Console.ReadKey();
                    }
                    else if(arrd != null)
                    {
                        Console.WriteLine("Массив int не инициализирован");
                        PrintArray(arrd);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Массив int не инициазирован");
                        Console.WriteLine("Массив double не инициализирован");
                        Console.ReadKey();
                    }
                    break;
                    case 3:
                    if((arrd == null && arri == null))
                    {
                        Console.WriteLine("Ни один из массивов не инициализирован");
                        Console.ReadKey();
                        break;
                    }
                    solution = MakeChoice("Удалить из массива с int","Удалить из массива с double");
                    if(solution)
                    {
                        if(arrd != null)
                        {
                            if(arrd.Length == 0)
                            {
                                Console.WriteLine("Массив пуст, нечего удалять!");
                                Console.ReadKey();
                            }
                            else
                            {
                                arrd = DelStringFromArr(arrd);
                            }
                        }
                        else
                            {
                                Console.WriteLine("Перед тем, как изменять массив, его надо инициализировать");
                                Console.ReadKey();
                            }
                    }
                    else
                    {
                        if(arri != null)
                        {
                            if(arri.Length == 0)
                            {
                                Console.WriteLine("Массив пуст, нечего удалять!");
                                Console.ReadKey();
                            }
                            else
                            {
                                arri = DelStringFromArr(arri);
                            }
                        }
                        else
                            {
                                Console.WriteLine("Перед тем, как изменять массив, его надо инициализировать");
                                Console.ReadKey();
                            }
                    }
                    break;
                    

                }
                PrintMenu(2);
            }while(step != 0);
        }

        static void JagArrMenu()
        {
            PrintMenu(3);

            int [][] arri = null;
            double [][] arrd = null;

            int step;
            bool solution;

            do
            {
                step = InputNumInt(">> ", "Ошибка ввода");
                switch(step)
                {
                    case 1:
                    solution = MakeChoice("Массив int","Массив double");
                    if(solution)
                    {
                        arrd = MakeArr_double();
                    }
                    else
                    {
                        arri = MakeArr_int();
                    }
                    Console.WriteLine("Инициализация массива завершена");
                    Console.ReadKey();
                    break;
                    case 2:
                    if(arri != null && arrd != null)
                    {
                        PrintArray(arri);
                        PrintArray(arrd);
                        Console.ReadKey();
                    }
                    else if(arri != null)
                    {
                        PrintArray(arri);
                        Console.WriteLine("Массив double не инициализирован");
                        Console.ReadKey();
                    }
                    else if(arrd != null)
                    {
                        Console.WriteLine("Массив int не инициализирован");
                        PrintArray(arrd);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Массив int не инициазирован");
                        Console.WriteLine("Массив double не инициализирован");
                        Console.ReadKey();
                    }
                    break;
                    case 3:
                    if(arri == null && arrd == null)
                    {
                        Console.WriteLine("Ни один из массивов не инициализирован");
                        Console.ReadKey();
                        break;
                    }
                    solution = MakeChoice("Добавить в массив с int", "Добавить в массив с double");
                    if(solution)
                    {
                        if(arrd != null)
                            arrd = AddJagArrBeg(arrd);
                        else
                            {
                                Console.WriteLine("Перед тем, как добавить элемент в массив, его надо инициализировать");
                                Console.ReadKey();
                            }
                    }
                    else
                    {
                        if(arri != null)
                            arri = AddJagArrBeg(arri);
                        else
                            {
                                Console.WriteLine("Перед тем, как добавить элемент в массив, его надо инициализировать");
                                Console.ReadKey();
                            }
                    }
                    break;

                }
                PrintMenu(3);
            }while(step != 0);
        }



        //Служебные функции

        static bool MakeChoice(string sol1 = "Вариант 1", string sol2 = "Вариант 2")
        {
            Console.WriteLine("Выбор:\n"+"(0)"+sol1+"\t"+"(1)"+sol2);
            
            bool f = Convert.ToBoolean(InputNumInt("0/1\t","Введите целое число"));

            return f;
        }
        static int InputNumInt(string invMsg = "", string errMsg ="")//Ввод целового числа
        {
            Console.Write(invMsg);
            while(true)
            {
                int result;
                if(int.TryParse(Console.ReadLine(),out result))
                    return result;
                Console.WriteLine(errMsg);
                Console.Write(invMsg);
            }
        }
        
        static double InputNumDouble(string invMsg = "", string errMsg ="")//Ввод целового числа
        {
            Console.Write(invMsg);
            while(true)
            {
                double result;
                if(double.TryParse(Console.ReadLine(),out result))
                    return result;
                Console.WriteLine(errMsg);
                Console.Write(invMsg);
            }
        }
        
        static int InputNumOfElements(string invMsg = "Введите количество элементов: ")
        {
            Console.Clear();
            Console.WriteLine(invMsg);
            int a;
            do
            {
                a = InputNumInt("","Введите целое число больше 0");
                
            }while(a < 1);

            return a;
        }

        static int InputNumK(int rBord)
        {
            int k;

            do
            {
                k = InputNumInt($"Введите число от 1 до {rBord}: ","Ошибка!");
            }while(k<1 || k > rBord);


            return k;
        }

    ////
    //////Работа с массивами
    ////

        //Одномерный массив
        static int[] MakeArr_int(int n)
        {
            Console.Clear();

            int[] resultArr = new int[n];

            Console.WriteLine("Каким способом заполнить массив?");
            bool isManual = MakeChoice("Вручную","ДСЧ");

            if(isManual)
            {
                resultArr = InitArrRnd_int(n);
            }
            else
            {
                resultArr = InitArrMan_int(n);
            }

            return resultArr;
        }

        static int[] InitArrRnd_int(int length)
        {
            int[] arr = new int[length];

            Random rnd = new Random(rndSeed);
            Console.WriteLine("Инициализированный массив");
            for(int i = 0; i < length; i++)
            {
                arr[i] = rnd.Next(-128,127);
                Console.Write($"{arr[i]}" + " ");
            }
            Console.WriteLine();
            rndSeed = rnd.Next(-length,length);

            return arr;
        }
    
    
        
        
        static int[] InitArrMan_int(int length)
        {
            int[] arr = new int[length];

            Console.WriteLine("Инициализация массива: ");
            for(int i = 0; i < length; i++)
            {
                arr[i] = InputNumInt("","Введите целое число!");
            }

            return arr;
        }

        static double[] MakeArr_double(int n)
        {
            Console.Clear();

            double[] resultArr = new double[n];

            Console.WriteLine("Каким способом заполнить массив?");
            bool isManual = MakeChoice("Вручную","ДСЧ");

            if(isManual)
            {
                resultArr = InitArrRnd_double(n);
            }
            else
            {
                resultArr = InitArrMan_double(n);
            }

            return resultArr;
        }

        static double[] InitArrRnd_double(int length)
        {
            double[] arr = new double[length];

            Random rnd = new Random(rndSeed);
            Console.WriteLine("Инициализированный массив");
            for(int i = 0; i < length; i++)
            {
                arr[i] = Math.Round((double)rnd.Next(-128,127) / (double)rnd.Next(-128,127),2);
                Console.Write($"{arr[i]}" + " ");
            }
            Console.WriteLine();
            rndSeed = rnd.Next(-length,length);

            return arr;
        }

        static double[] InitArrMan_double(int length)
        {
            double[] arr = new double[length];

            Console.WriteLine("Инициализация массива: ");
            for(int i = 0; i < length; i++)
            {
                
                arr[i] = InputNumDouble("","Введите число!");
            }

            return arr;
        }

        static void PrintArray(int[] arr)
        {
            Console.WriteLine("Массив int: ");
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }

        static void PrintArray(double[] arr)
        {
            Console.WriteLine("Массив double: ");
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }

        static int[] AddArrK(int[] array)
        {
            int newlength = array.Length+1;
            int[] buff = new int[newlength];
            Console.Clear();

            int k = InputNumK(newlength);           //Место для вставки

            k--;

            int el = InputNumInt("Введите целое число: ","Ошибка!");                              //Элемент для вставки

            if(k == newlength)
            {
                for(int i = 0; i < newlength-1;i++)
                {
                    buff[i] = array[i];
                }
                buff[newlength-1] = el;
            }
            else if(k == 0)
            {
                buff[0] = el;
                for(int i =0; i < newlength-1; i++)
                {
                    buff[i+1] = array[i];
                }
            }
            else
            {
            
            for(int i =0; i < k;i++)
            {
                buff[i] = array[i];
            }
            buff[k] = el;
            for(int i = k+1; i < newlength; i++)
            {
                buff[i] = array[i-1];
            }
            }
            return buff;
        }

        static double[] AddArrK(double[] array)
        {
            int newlength = array.Length+1;
            double[] buff = new double[newlength];
            Console.Clear();

            int k = InputNumK(newlength);           //Место для вставки

            k--;

            double el = InputNumDouble("Введите число: ","Ошибка!");                              //Элемент для вставки

            if(k == newlength)
            {
                for(int i = 0; i < newlength-1;i++)
                {
                    buff[i] = array[i];
                }
                buff[newlength-1] = el;
            }
            else if(k == 0)
            {
                buff[0] = el;
                for(int i =0; i < newlength-1; i++)
                {
                    buff[i+1] = array[i];
                }
            }
            else
            {
            
                for(int i =0; i < k;i++)
                {
                    buff[i] = array[i];
                }
                buff[k] = el;
                for(int i = k+1; i < newlength; i++)
                {
                    buff[i] = array[i-1];
                }
            }
            return buff;
        }

        //Двумерный массив
        
        static int[,] MakeArr_int(int n, int m)
        {
            Console.Clear();

            int[,] resultArr = new int[n,m];

            Console.WriteLine("Каким способом заполнить массив?");
            bool isManual = MakeChoice("Вручную","ДСЧ");

            if(isManual)
            {
                resultArr = InitArrRnd_int(n,m);
            }
            else
            {
                resultArr = InitArrMan_int(n,m);
            }

            return resultArr;
        }

        static int[,] InitArrRnd_int(int length, int height)
        {
            int[,] arr = new int[length,height];

            Random rnd = new Random(rndSeed);
            Console.WriteLine("Инициализированный массив");
            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    arr[i,j] = rnd.Next(-128,127);
                    Console.Write($"{arr[i,j]}" + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            rndSeed = rnd.Next(-length,length);

            return arr;
        }

        static int[,] InitArrMan_int(int length, int height)
        {
            int[,] arr = new int[length,height];

            Console.WriteLine("Инициализация массива: ");
            for(int i = 0; i < length; i++)
            {
                Console.WriteLine($"Ввод arr[{i},j]:");
                for(int j =0; j < height; j++)
                {
                    arr[i,j] = InputNumInt("","Введите целое число!");
                } 
                
            }

            return arr;
        }

        static double[,] MakeArr_double(int n, int m)
        {
            Console.Clear();

            double[,] resultArr = new double[n,m];

            Console.WriteLine("Каким способом заполнить массив?");
            bool isManual = MakeChoice("Вручную","ДСЧ");

            if(isManual)
            {
                resultArr = InitArrRnd_double(n,m);
            }
            
            else
            {
                resultArr = InitArrMan_double(n,m);
            }

            return resultArr;
        }

        static double[,] InitArrRnd_double(int length, int height)
        {
            double[,] arr = new double[length,height];

            Random rnd = new Random(rndSeed);
            Console.WriteLine("Инициализированный массив");
            for(int i = 0; i < length; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    arr[i,j] = Math.Round((double)rnd.Next(-128,127) / (double)rnd.Next(-128,127),2);
                    Console.Write($"{arr[i,j]}" + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            rndSeed = rnd.Next(-length,length);

            return arr;
        }


        static double[,] InitArrMan_double(int length, int height)
        {
            double[,] arr = new double[length,height];

            Console.WriteLine("Инициализация массива: ");
            for(int i = 0; i < length; i++)
            {
                Console.WriteLine($"Ввод arr[{i},j]:");
                for (int j = 0; j < height; j++)
                {
                    arr[i,j] = InputNumDouble("","Введите число!");
                }
                
            }

            return arr;
        }

        static void PrintArray(int[,] arr)
        {
            Console.WriteLine("Массив int: ");
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintArray(double[,] arr)
        {
            Console.WriteLine("Массив double: ");
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int[,] DelStringFromArr(int[,] array)
        {
            int[,] result = new int[array.GetLength(0) - 1,array.GetLength(1)];

            int k = FindStringWithMax(array);                           //индекс строчки, которую следует удалить
            if(k != result.GetLength(0))
            {
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        result[i,j] = array[i,j];
                    }
                    
                }

                for(int i = k; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        result[i,j] = array[i+1,j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        result[i,j] = array[i,j];
                    }
                    
                }
            }


            
            return result;
        }

        static double[,] DelStringFromArr(double[,] array)
        {
            double[,] result = new double[array.GetLength(0) - 1,array.GetLength(1)];

            int k = FindStringWithMax(array);                           //индекс строчки, которую следует удалить
            if(k != result.GetLength(0))
            {
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        result[i,j] = array[i,j];
                    }
                    
                }

                for(int i = k; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        result[i,j] = array[i+1,j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        result[i,j] = array[i,j];
                    }
                    
                }
            }
            
            return result;
        }

        static int FindStringWithMax(int[,] array)
        {
            int k = 0;
            int max = int.MinValue;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if(array[i,j] > max)
                    {
                        max = array[i,j];
                        k = i;
                    }
                }
            }
            return k;
        }

        static int FindStringWithMax(double[,] array)
        {
            int k = 0;
            double max = double.MinValue;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if(array[i,j] > max)
                    {
                        max = array[i,j];
                        k = i;
                    }
                }
            }
            return k;
        }


        //Рваный массив

        static int[][] MakeArr_int()
        {
            Console.Clear();
            int n = InputNumOfElements("Кол-во строк в рванном массиве: ");
            int[][] resultArr = new int[n][];


            Console.WriteLine("Каким способом заполнить массив?");
            bool isManual = MakeChoice("Вручную","ДСЧ");

            if(isManual)
            {
                resultArr = InitArrRnd_int(n,true);
            }
            else
            {
                resultArr = InitArrMan_int(n,true);
            }

            return resultArr;
        }

        static int[][] InitArrRnd_int(int height, bool b)
        {
            int[][] arr = new int[height][];
            for (int i = 0; i < height; i++)
            {
                int cols = InputNumOfElements($": кол-во элементов в строке {i+1}");

                int[] row = InitArrRnd_int(cols);
                arr[i] = row;
            }

            return arr;
        }

        static int[][] InitArrMan_int(int height, bool b)
        {
            int[][] arr = new int[height][];
            for (int i = 0; i < height; i++)
            {
                int cols = InputNumOfElements($": кол-во элементов в строке {i+1}");

                int[] row = InitArrMan_int(cols);
                arr[i] = row;
            }

            return arr;
        }

        static double[][] MakeArr_double()
        {
            Console.Clear();
            int n = InputNumOfElements("Кол-во строк в рванном массиве: ");
            double[][] resultArr = new double[n][];


            Console.WriteLine("Каким способом заполнить массив?");
            bool isManual = MakeChoice("Вручную","ДСЧ");

            if(isManual)
            {
                resultArr = InitArrRnd_double(n,true);
            }
            else
            {
                resultArr = InitArrMan_double(n,true);
            }

            return resultArr;
        }

        static double[][] InitArrRnd_double(int height, bool b)
        {
            double[][] arr = new double[height][];
            for (int i = 0; i < height; i++)
            {
                int cols = InputNumOfElements($": кол-во элементов в строке {i+1}");

                double[] row = InitArrRnd_double(cols);
                arr[i] = row;
            }

            return arr;
        }

        static double[][] InitArrMan_double(int height, bool b)
        {
            double[][] arr = new double[height][];
            for (int i = 0; i < height; i++)
            {
                int cols = InputNumOfElements($": кол-во элементов в строке {i+1}");

                double[] row = InitArrMan_double(cols);
                arr[i] = row;
            }

            return arr;
        }

        static void PrintArray(int[][] array)
        {
            Console.WriteLine("Массив int: ");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void PrintArray(double[][] array)
        {
            Console.WriteLine("Массив double: ");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static int[][] AddJagArrBeg(int[][] array)
        {
            int[][] result = new int[array.Length+1][];

            int n = InputNumOfElements("Введите длину строчки для вставки: ");

            Console.WriteLine("Как инициализировать строку?");
            bool solution = MakeChoice("Ручной ввод","ДСЧ");

            if(solution)
                result[0] = InitArrRnd_int(n);
            else
                result[0] = InitArrMan_int(n);

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = array[i-1];
            }

            return result;
        }

        static double[][] AddJagArrBeg(double[][] array)
        {
            double[][] result = new double[array.Length+1][];

            int n = InputNumOfElements("Введите длину строчки для вставки: ");

            Console.WriteLine("Как инициализировать строку?");
            bool solution = MakeChoice("Ручной ввод","ДСЧ");

            if(solution)
                result[0] = InitArrRnd_double(n);
            else
                result[0] = InitArrMan_double(n);

            for (int i = 1; i < result.Length; i++)
            {
                result[i] = array[i-1];
            }

            return result;
        }

    }
}
