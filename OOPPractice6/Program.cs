using System;
using System.Text.RegularExpressions;

namespace OOPPractice6
{
    class Program
    {
        /// 
        /// Статические переменные
        /// 
            static int rndSeed = 1337;
            static Random rndGenerator = new Random(rndSeed);

        /// 
        /// Начало программы(Функция main)
        /// 
        
        static void Main(string[] args)
        {
            RunMenu();
        }



        /// 
        /// Меню
        /// 

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
                    Task1Menu();
                    PrintMenu(0);
                    break;
                    case 2:
                    Task2Menu();
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
                rndGenerator.Next(-256,255);
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
                break;
                case 1:
                Console.WriteLine("\tЗадание 1");
                Console.WriteLine("1. Создать массив");
                Console.WriteLine("2. Печать массива");
                Console.WriteLine("3. Удалить из массива последнюю гласную букву");
                break;
                case 2:
                Console.WriteLine("\tЗадание 2");
                Console.WriteLine("1. Создать строку");
                Console.WriteLine("2. Печать строки");
                Console.WriteLine("3. Перевернуть каждое слово, номер которого совпадает с его длиной");
                break;
                
            }
            rndSeed = rndGenerator.Next(-256,255);
            rndGenerator.Next(-256,255);
            Console.WriteLine("\n10. Очистка консоли");
            Console.WriteLine("0. Назад");
        }

        static void Task1Menu()
        {
            PrintMenu(1);
            int step;

            char[] arrch = null;
            do
            {
                step = InputNumInt(">> ", "Ошибка ввода");

                switch (step)
                {
                    case 1:
                        arrch = MakeArr_char(InputNumOfElements("Кол-во элементов в массиве?"));
                        Console.WriteLine("Инициализация массива окончена");
                        Console.WriteLine("Нажмите любую кнопку для продолжения...");
                        Console.ReadKey();
                    break;
                    case 2:
                        PrintArr(arrch);
                    break;
                    case 3:
                        arrch = DelElVowel(arrch);
                    break;


                    default:
                    break;
                }


                PrintMenu(1);
                rndSeed = rndGenerator.Next(-256,255);
            } while (step != 0);
        }

        static void Task2Menu()
        {
            PrintMenu(2);

            int step;
            

            string str = null;
            do
            {
                step = InputNumInt(">> ", "Ошибка ввода");

                switch (step)
                {
                    case 1:
                        str = CreateString();
                    break;
                    case 2:
                        PrintStr(str);
                    break;
                    case 3:
                        if(str != null)PrintStr("Строка до перестановки: " + str);
                            str = ReverseWords(str);
                        if(str != null)PrintStr("Строка после перестановки: " + str);
                    break;
                    default:
                    break;
                }

                PrintMenu(2);
            } while (step != 0);
            
        }

        ///
        ///Работа с массивами 
        /// 
        static char[] MakeArr_char(int n)
        {
            Console.Clear();

            char[] resultArr = new char[n];

            Console.WriteLine("Каким способом заполнить массив?");
            bool isManual = MakeChoice("Вручную","ДСЧ");

            if(isManual)
            {
                resultArr = InitArrRnd_char(n);
            }
            else
            {
                resultArr = InitArrMan_char(n);
            }

            return resultArr;
        }

        static char[] InitArrRnd_char(int length)
        {
            char[] arr = new char[length];

            Random rnd = new Random(rndSeed);
            Console.WriteLine("Инициализированный массив");
            for(int i = 0; i < length; i++)
            {
                arr[i] = Convert.ToChar(rnd.Next(0,256));
                Console.Write($"{arr[i]}" + " ");
            }
            Console.WriteLine();
            rndSeed = rnd.Next(-length,length);

            return arr;
        }
    
    
        
        
        static char[] InitArrMan_char(int length)
        {
            char[] arr = new char[length];

            Console.WriteLine("Инициализация массива: ");
            for(int i = 0; i < length; i++)
            {
                arr[i] = InputChar("","Введите символ!");
            }

            return arr;
        }

        static void PrintArr(char[] arr)
        {
            try{
            if(isNullOrEmpty(arr))
                throw new Exception("Массив не инициализирован или пуст");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey();
            }
            catch(Exception er){
                Console.WriteLine("Ошибка!\n" + er.Message);
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
            }
        }

        static char[] DelElVowel(char[] array)
        {
            try
            {
                if(isNullOrEmpty(array))
                    throw new Exception("Массив не инициализирован или пуст");
                int k = FindLastVowel(array);

                if(k == -1)
                {
                    Console.WriteLine("Массив не содержит гласных букв");
                    Console.ReadKey();
                    return array;
                }
                
                char[] result = new char[array.Length-1];
                for (int i = 0; i < k; i++)
                {
                    result[i] = array[i];
                }
                for(int i = k+1; i < array.Length;i++)
                {
                    result[i-1] = array[i];
                }
                

                if(result.Length>0)
                    PrintArr(result);
                return result;  
            }
            catch(Exception er)
            {
                Console.WriteLine("Ошибка! " + er.Message);
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
                return null;
            }
        }

        static int FindLastVowel(char[] array)
        {
            char[] vowels = new char[] {'у','е', 'ё','ы','а','о','э','я','и','ю','e','u','o','a','У','Е', 'Ё','Ы','А','О','Э','Я','И','Ю','E','U','O','A'};        

            int k = array.Length - 1;
            for (int i = k; i  >= 0;i--)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if(array[i] == vowels[j])
                        return i;
                }
            }
            return -1;
        }

        ///
        ///Работа со строкой 
        ///     
        
        
        static string InitStringByManual(string invMsg = "",string errMsg = "Ошибка. Строка не инициализирована")
        {
            string result;

            try
            {
                Console.WriteLine(invMsg);
                result = Console.ReadLine();
                Console.WriteLine("Строка инициализирована");
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
            return result;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Ошибка! " + errMsg);
                return null;
            }            
        }

        static string InitStringByTemplates()
        {
            Console.WriteLine("\t Выбор примера:");

            string[] strArr = new string[] {"Hello world! How are you, my little friend?",
                                            "How are you? What are you doing?",
                                            "Здравствуй Мартин Алексеевич, твоя жизнь как?",
                                            "Чем вы нас покормите? - спросил голодный двоишник Петя Максимов.",
                                            "Может быть, тебе дать еще ключ от квартиры, где деньги лежат?",
                                            "Почём опиум для народа?",
                                            "Я, конечно, не херувим. У меня нет крыльев, но я чту Уголовный кодекс. Это моя слабость."};

            for (int i = 0; i < strArr.Length; i++)
            {
                Console.WriteLine($"{i+1}. {strArr[i]}");
            }
            
            int k = InputNumK(strArr.Length);

            
            

            return strArr[k-1];
        }

        static string CreateString()
        {
            bool solution = MakeChoice("Ввод вручную","Ввод с помощью программы");
            if(!solution)
            {
                return InitStringByManual("Введите строку: ", "Строка не инициализирована");
            }
            else
            {
                return InitStringByTemplates();
            }

        }
        static void PrintStr(string str)
        {
            try
            {
                if(str == null)
                    throw new Exception("\nСтрока не инициализирована!");
                Console.WriteLine(str);
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();

            }
            catch(Exception er)
            {
                Console.WriteLine("Ошибка! " + er.Message);
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
            }
           
        }

        
        static string ReverseWords(string str)
        {
            try
            {
                if(str == null)
                    throw new Exception("Строка не инициализирована!");


                string layout = SetLayout(str);
                str = SetSentence(str);
                

                

                string[] strArr = str.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                string[] layoutArr = layout.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                Regex regex = new Regex(@"[_]");
                

                string result = "";
                for(int i= 0; i < strArr.Length;i++)
                {
                    if(strArr[i].Length == i+1)
                        strArr[i] = StringReverse(strArr[i]);

                        
                    layoutArr[i] = regex.Replace(layoutArr[i],strArr[i])+" ";


                    result += layoutArr[i]; 
                }

                return result;
            }
            catch(Exception er)
            {
                Console.WriteLine($"Ошибка!\n{er.Message}");
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
                return null;
            }

            
        }

        static string SetSentence(string str)
        {
            string result = " ";

            Regex regex = new Regex(@"\W");

            result = regex.Replace(str,result);

            return result;           
        }
        static string SetLayout(string str)
        {
            string result = "_";
            

            Regex regex = new Regex(@"\w(?<!\d)[\w'-]*");

            result = regex.Replace(str,result);

            
            
            return result;
        }

        static string StringReverse(string str)
        {
            char[] array = str.ToCharArray();
            Array.Reverse(array);

            return new string(array);
        }

        ///
        ///Вспомогательные функции
        ///


        static int InputNumK(int rBord)
        {
            int k;

            do
            {
                k = InputNumInt($"Введите число от 1 до {rBord}: ","Ошибка!");
            }while(k<1 || k > rBord);


            return k;
        }
        static bool isNullOrEmpty(char[] arr)
        {
            if(arr == null || arr.Length == 0)
                return true;
            return false;
        }

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

        static char InputChar(string invMsg = "", string errMsg ="")//Ввод целового числа
        {
            Console.Write(invMsg);
            while(true)
            {
                char result;
                try
                {
                    if(!char.TryParse(Console.ReadLine(), out result))
                        throw new Exception(errMsg);

                    return result;
                }
                catch(Exception er)
                {
                    Console.WriteLine(er.Message);
                }
                
            }
        }
        static int InputNumOfElements(string invMsg = "")
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

        

        
    }
}
