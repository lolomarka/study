using System;
//Вариант лабораторной работы №19.
namespace OOP.Practice4
{
    class Program
    {   //Переменные
        static int[] arr; //Массив
        static int menuX = 1;

       


        static Random rnd = new Random(setRndSeed());
        static int Max = Int32.MinValue;
        static int indMax = -1;
        
        //Функции и методы
        
        static bool isFoundMax()
        {
            if(Max != Int32.MinValue || indMax != -1)
                return true;
            else return false;
        }
         static bool isArrInit()
        {
            if(arr != null) return true;
            else return false;
        }
        static int intInput(string InvMes = "")//ввод любой переменной int.
        {
            int a;
            bool ok;
            string buf;
            do
            {
                Console.Write(InvMes);
                buf = Console.ReadLine();
                ok = int.TryParse(buf, out a);
                if(!ok) Console.WriteLine("Введите целое число!");
            }while(!ok);

            return a;
        }

        static int[] SetArray(bool flag)//false - дсч; true - клавиатура
        {
            
            int n;
            n = Math.Abs(intInput("n? "));
            if(flag)
            {   
                
                int[] arr = new int[n];
                Console.WriteLine("Начало ввода данных в массив:");
                for(int i = 0; i < n; i++)
                {
                    arr[i] = intInput();
                }
                Console.WriteLine("Ввод окончен");

                return arr;
            }
            else
            {
                int[] arr = new int[n];
                Console.WriteLine("Массив будет инициализирован с помошью ДСЧ\nСгенерированный массив:");
                
                for(int i = 0; i < n; i++)
                {
                    arr[i] = rnd.Next(-128,127);
                    Console.Write($"{arr[i]} ");
                }
                Console.WriteLine();
                return arr;
            }

        }

        static void PrintArray(int[] arr)//вывод массива в консоль
        {
            Console.WriteLine("Печать массива:");
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("\nПечать окончена.");
        }
        
        static int FindMax(int[] arr)//поиск максимального значения
        {   
            int Max = Int32.MinValue;

            for(int i = 0; i < arr.Length; i++)
            {
                Max = (arr[i]> Max) ? arr[i] : Max;     
            }

            return Max;
        }

        static int FindIndMax(int[] arr)//поиск индекс максимального значения
        {
            int Max = Int32.MinValue;
            int ind = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                ind = (arr[i]> Max) ? i : ind;
                Max = (arr[i]> Max) ? arr[i] : Max;     
            }

            return ind;
        }

        static int[] DelEl(int[] arr, int ind)//Удаление элемента массива по индексу
        {
            if(arr.Length == 0)
            {
                Console.WriteLine("Массив пуст!");
                return arr;
            }
            int[] bufarr = new int[arr.Length - 1];
            for(int i = 0; i < ind; i++)
            {
                bufarr[i] = arr[i];
            }
            for(int i = ind + 1; i < arr.Length; i++)
            {
                bufarr[i-1] = arr[i];
            }
            
            Console.WriteLine($"Удалён элемент с индексом: {ind}");
            return bufarr;
        }
        
        static int[] AppNK(int[] arr)
        {
            Console.WriteLine("Ввод массива для вставки:\nДСЧ(0)/Клавиатура(1)?");
            bool flg = Convert.ToBoolean(intInput());
            int[] addarr = SetArray(flg);
            Console.WriteLine("Массив для вставки:");
            PrintArray(addarr); 
            bool ok = false;
            int k;
            do
            {
                k = intInput("k? ");
                k = (k < 0)? 0: k;
                if(arr.Length == 0)
                    arr = new int[1];
                if(k >= 0 && k <= arr.Length)
                {
                    ok = true;
                } 
                Console.WriteLine("Недопустимый ввод!");
            }while(!ok);

            int balen = arr.Length + addarr.Length; //длина bufarr
            int[] bufarr = new int[balen];

            for(int i = 0; i < k; i++)
            {
                bufarr[i] = arr[i];
            }
            for(int i = k; i < k + addarr.Length; i++)
            {
                bufarr[i] = addarr[i-k];
            }
            for(int i = k+addarr.Length; i < balen; i++)
            {
                bufarr[i] = arr[i - addarr.Length];
            }

            return bufarr;
        }

        static void printMainMenu(int x)
        {
            switch (x)
            {
                case 1:
                    Console.WriteLine("1)Создать массив *\n2)Найти максимальный элемент\n3)Удалить максимальный элемент\n4)Вставить подмассив\n5)Четные - начало / Нечётные - конец\n6)Поиск\n7)Сортировка простым обменом\n8)Вывод массива\n9)Бинарный поиск");
                    break;
                case 2:
                    Console.WriteLine("1)Создать массив\n2)Найти максимальный элемент *\n3)Удалить максимальный элемент\n4)Вставить подмассив\n5)Четные - начало / Нечётные - конец\n6)Поиск\n7)Сортировка простым обменом\n8)Вывод массива\n9)Бинарный поиск");
                    break;
                case 3:
                    Console.WriteLine("1)Создать массив\n2)Найти максимальный элемент\n3)Удалить максимальный элемент *\n4)Вставить подмассив\n5)Четные - начало / Нечётные - конец\n6)Поиск\n7)Сортировка простым обменом\n8)Вывод массива\n9)Бинарный поиск");
                    break;
                case 4:
                    Console.WriteLine("1)Создать массив\n2)Найти максимальный элемент\n3)Удалить максимальный элемент\n4)Вставить подмассив *\n5)Четные - начало / Нечётные - конец\n6)Поиск\n7)Сортировка простым обменом\n8)Вывод массива\n9)Бинарный поиск");
                    break;
                case 5:
                    Console.WriteLine("1)Создать массив\n2)Найти максимальный элемент\n3)Удалить максимальный элемент\n4)Вставить подмассив\n5)Четные - начало / Нечётные - конец *\n6)Поиск\n7)Сортировка простым обменом\n8)Вывод массива\n9)Бинарный поиск");
                    break;
                case 6:
                    Console.WriteLine("1)Создать массив\n2)Найти максимальный элемент\n3)Удалить максимальный элемент\n4)Вставить подмассив\n5)Четные - начало / Нечётные - конец\n6)Поиск *\n7)Сортировка простым обменом\n8)Вывод массива\n9)Бинарный поиск");
                    break;
                case 7:
                    Console.WriteLine("1)Создать массив\n2)Найти максимальный элемент\n3)Удалить максимальный элемент\n4)Вставить подмассив\n5)Четные - начало / Нечётные - конец\n6)Поиск\n7)Сортировка простым обменом *\n8)Вывод массива\n9)Бинарный поиск");
                    break;
                case 8:
                    Console.WriteLine("1)Создать массив\n2)Найти максимальный элемент\n3)Удалить максимальный элемент\n4)Вставить подмассив\n5)Четные - начало / Нечётные - конец\n6)Поиск\n7)Сортировка простым обменом\n8)Вывод массива *\n9)Бинарный поиск");
                    break;
                case 9:
                    Console.WriteLine("1)Создать массив\n2)Найти максимальный элемент\n3)Удалить максимальный элемент\n4)Вставить подмассив\n5)Четные - начало / Нечётные - конец\n6)Поиск\n7)Сортировка простым обменом\n8)Вывод массива\n9)Бинарный поиск *");
                    break;
                
                default:
                    Console.WriteLine("1)Создать массив\n2)Найти максимальный элемент\n3)Удалить максимальный элемент\n4)Вставить подмассив\n5)Четные - начало / Нечётные - конец\n6)Поиск\n7)Сортировка простым обменом\n8)Вывод массива\n9)Бинарный поиск");
                    break;
                    

            }
            
        }

        static void callFunc(int x)
        {
            Console.Clear();
            switch(x)
            {
                case 1:
                    Console.WriteLine("Ввод: ДСЧ(0)/Клавиатура(1)?");
                    bool flag = Convert.ToBoolean(intInput());
                    arr = SetArray(flag);
                    PrintArray(arr);
                    Console.ReadKey();
                    break;
                case 2:
                    if(isArrInit())
                    {
                        if(arr.Length == 0)
                        {
                            Console.WriteLine("Массив пуст!\nНевозможно найти максимум!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Max = FindMax(arr);
                            indMax = FindIndMax(arr);
                            Console.WriteLine($"Max = {Max}\nindMax = {indMax}");
                            Console.ReadKey();
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Ошибка!\nМассив ещё не инициализирован!");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    if(isArrInit() && isFoundMax())
                    {
                        indMax = FindIndMax(arr);
                        arr = DelEl(arr,indMax);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ошибка!\nЛибо не инициализирован массив\nЛибо ещё не найден максимальный элемент\nЛибо пуст");
                        Console.ReadKey();
                    }
                    break;
                case 4:
                    if(isArrInit())
                    {
                        arr = AppNK(arr);
                        PrintArray(arr);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка!\nНе инициализирован массив");
                    }
                    break;
                case 5:
                    if(isArrInit())
                    {
                        arr = evenOdd(arr);
                        PrintArray(arr);
                        Console.ReadKey();
                    }
                    else Console.WriteLine("Ошибка!\nНе инициализирован массив");
                    break;
                case 6:
                    if(isArrInit())
                    {
                        int val = intInput("Введите искомое число: ");
                        int rezsearch = search(arr, val);
                        if(rezsearch > -1) Console.WriteLine($"Искомое значение val = {val} найдено!\nИтераций для поиска = {rezsearch}");
                        else Console.WriteLine("Заданное значение в массиве не представленно");
                        
                        Console.ReadKey();    
                    }
                    else Console.WriteLine("Ошибка!\nНе инициализирован массив");
                    break;
                case 7:
                    if(isArrInit())
                    {
                        bubbleSort(arr);
                        PrintArray(arr);

                        Console.ReadKey();
                    }
                    else Console.WriteLine("Ошибка!\nНе инициализирован массив");
                    break;
                case 8:
                    if(isArrInit())
                    {
                        PrintArray(arr);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ошибка!\nНе инициализирован массив");
                        Console.ReadKey();   
                    }
                    break;
                case 9:
                    if(isArrInit() && isSorted(arr))
                    {
                        int key = intInput("Введите ключ: ");
                        int a = BinarySearchIter(arr,key);
                        int rezsearch = search(arr,key) - 1;
                        
                        if(a == -1) Console.WriteLine("Ключа в массиве не оказалось!");
                        else 
                        {
                            Console.WriteLine("Ключевое значение найдено!");
                            
                            Console.WriteLine($"Индекс элемента: {rezsearch}");
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ошибка!\nЛибо не инициализирован массив\nЛибо массив не отсортирован!");
                        Console.ReadKey();
                    }
                    break;
                default:
                    Console.WriteLine("Ошибка!");
                    break;
            }
        }

        
        static void eventMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                
                key = Console.ReadKey();

                //Выбор пунктов меню на кнопки
                if(key.Key == ConsoleKey.D1) callFunc(1);
                if(key.Key == ConsoleKey.D2) callFunc(2);
                if(key.Key == ConsoleKey.D3) callFunc(3);
                if(key.Key == ConsoleKey.D4) callFunc(4);
                if(key.Key == ConsoleKey.D5) callFunc(5);
                if(key.Key == ConsoleKey.D6) callFunc(6);
                if(key.Key == ConsoleKey.D7) callFunc(7);
                if(key.Key == ConsoleKey.D8) callFunc(8);
                if(key.Key == ConsoleKey.D9) callFunc(9);

                if(key.Key == ConsoleKey.UpArrow) menuX--;      //обработка нажатия стрелки вверх
                if(key.Key == ConsoleKey.DownArrow) menuX++;    //Обработка нажатия стрелки вниз
                
                if(menuX < 1) menuX = 9; //Перескок
                if(menuX > 9) menuX = 1; //Перескок

                if(key.Key == ConsoleKey.Enter) callFunc(menuX);

                Console.Clear();
                printMainMenu(menuX);

            }while(key.Key != ConsoleKey.Escape);
        }

        static int cntEven(int[] arr)
        {
            int cnt = 0;

            for(int i = 0;  i < arr.Length; i++)
            {
                if(arr[i] % 2 == 0)
                    cnt++;
            }
            return cnt;
        }
        static int[] even(int[] arr)
        {
            int[] bufarr = new int[cntEven(arr)];
            int ii = 0;
            for(int i = 0; i < arr.Length;i++)
            {
                if(arr[i] % 2 == 0)
                {
                    bufarr[ii] = arr[i];
                    ii++;
                }
            }

            return bufarr;
        }

        static int cntOdd(int[] arr)
        {
            int cnt = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i]%2 != 0)
                    cnt++;
            }
            return cnt;
        }

        static int[] odd(int[] arr)
        {
            int[] bufarr = new int[cntOdd(arr)];
            int ii = 0;
            for(int i = 0;i < arr.Length;i++)
            {
                if(arr[i] % 2 != 0)
                {
                    bufarr[ii] = arr[i];
                    ii++;
                }
            }
            return bufarr;
        }
        static int[] evenOdd(int[] arr)
        {
            int[] bufarr = new int[arr.Length];

            int[] evenarr = even(arr);
            int[] oddarr = odd(arr);
            for(int i = 0; i < cntEven(arr); i++)
            {
                bufarr[i] = evenarr[i];
            }

            for(int i = 0; i < cntOdd(arr); i++)
            {
                bufarr[evenarr.Length + i] = oddarr[i];
            }


            return bufarr;
        }

        static void bubbleSort(int[] arr)
        {
             // Для всех элементов
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = (arr.Length - 1); j > i; j--) // для всех элементов после i-ого
                {
                    if (arr[j - 1] > arr[j]) // если текущий элемент меньше предыдущего
                    {
                        int temp = arr[j - 1]; // меняем их местами
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

           
        }

        static bool isEmpty(ref int[] arr) //проверка на пустоту
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                return true;
            }
            else return false;
        }

        static bool isSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }

        
        static int BinarySearchIter(int[] arr, int key) //бинарный поиск целого числа в массиве
        {
            
            int min = 0;
            int max = arr.Length - 1;
            
            int iter = 0;
            while (min <= max)
            {
                iter++;
                int mid = (min + max) / 2;
                if (key == arr[mid])
                {
                    Console.WriteLine("Итераций: " + $"{iter}");
                    return mid;
                }
                else if (key < arr[mid]) max = mid - 1;
                else min = mid + 1;
            }
            Console.WriteLine("Итераций: " + $"{iter}");
            return -1;
        }

        


    

        static int search(int[] arr, int val)
        {
            int cnt = 0;
            for(int i =0; i < arr.Length; i++)
            {
                cnt++;
                if(arr[i] == val)
                    return cnt;
            }
            return -1;
        }

        static int setRndSeed()
        {
            return intInput("Введите зерно для генерации псевдослучайных чисел: ");
        }
        static void Main(string[] args)
        {
            Console.Clear();
            printMainMenu(-1);
            eventMenu();    
        }
    }
}
