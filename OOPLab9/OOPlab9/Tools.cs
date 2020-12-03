using System;


namespace OOPlab9
{
    public class Tools
    {
        static public int InputNumOfElements(string invMsg = "",string errMsg = "Ошибка: введите неотрицательное число")
        {
            Console.Clear();
            Console.WriteLine(invMsg);
            int a;
            do
            {
                
                a = InputNumInt("","Введите целое число больше 0");
                if(a < 1)
                {
                    Console.WriteLine(errMsg+"\nПовторите ввод: ");
                    return 0;
                }
            }while(a < 1);

            return a;
        }

        static public double InputNumDouble(string invMsg = "", string errMsg ="")//Ввод целового числа
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
            
            //Вид функции для тестов

            
            // Console.Write(invMsg);
          
            //     try
            //     {
            //         if(double.TryParse(console.InputLine(),out result))
            //         {
            //             return result;
            //         }
            //         else
            //         {
            //             throw new Exception(errMsg);
            //         }
            //     }
            //     catch(Exception err)
            //     {
            //         Console.WriteLine(err.Message);
                    
            //         return 0;
            //     }
            
        }

        static public double InputAbsNumDouble(string invMsg = "", string errMsg = "Ошибка! Введено неверное число")
        {
            double result;

            do
            {
                try
                {
                    result = InputNumDouble(invMsg,errMsg);
                    if (result < 0)
                        throw new Exception(errMsg);
                    return result;
                }
                catch(Exception err)
                {
                    Console.WriteLine("Ошибка! "+ err.Message);
                    Console.ReadKey();
                    return 0;
                }
            }while(result <= 0);
        }

        static public int InputNumInt(string invMsg = "", string errMsg ="Ошибка! Введено неверное число")//Ввод целового числа
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

            // int result;
            // Console.Write(invMsg);
          
            //     try
            //     {
            //         if(int.TryParse(console.InputLine(),out result))
            //         {
            //             return result;
            //         }
            //         else
            //         {
            //             throw new Exception(errMsg);
            //         }
            //     }
            //     catch(Exception err)
            //     {
            //         Console.WriteLine(err.Message);
                    
            //         return 0;
            //     }
            
        }


    }
    //Вспомогательный класс для тестов(помогает тестировать методы с вызовом консоли для ввода)
    public class console
    {
        static string InputString {get; set;}

        public console(string str)
        {
            InputString = str;
        }

        public console()
        {
            InputString = "0";
        }

        static public string ReadLine()
        {
            return Console.ReadLine();
        }

        static public string InputLine()
        {
            return InputString;
        }
    } 
}