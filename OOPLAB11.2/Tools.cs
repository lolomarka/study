using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using OOPlab10;


namespace OOPLAB11
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
        }


        static public Employee EmployeeConstructorDialog()
        {
            string name;
            int age;
            char sex;
            string position;

            name = InputString("Введите имя:");
            age = InputNumOfElements("Введите возраст:");
            sex = Convert.ToChar(InputString("Укажите пол:"));
            position = InputString("Укажите позицию");
            

            return new Employee(name, age, sex, position);
        }
        
        static public Engineer EngineerConstructorDialog()
        {
            string name;
            int age;
            char sex;
            string position;
            string university;
            int subdivision;
            
            name = InputString("Введите имя:");
            age = InputNumOfElements("Введите возраст:");
            sex = Convert.ToChar(InputString("Укажите пол:"));
            position = "Инженер";
            university = InputString("Введите название университета:");
            subdivision = InputNumOfElements("Введите номер подразделения");

            return new Engineer(name, age, sex, position,university,subdivision);
        }
        
        
        static public Administration AdministrationConstructorDialog()
        {
            string name;
            int age;
            char sex;
            string position;
            int numOfDeputy;
            name = InputString("Введите имя:");
            age = InputNumOfElements("Введите возраст:");
            sex = Convert.ToChar(InputString("Укажите пол:"));
            position = "Работник администрации";
            numOfDeputy = InputNumOfElements("Введите кол-во заместителей:");
            

            return new Administration(name, age, sex, position,numOfDeputy);
        }
        
        

        static public string InputString(string invMsg = "")
        {
            while(true)
                try
                {
                    Console.WriteLine(invMsg);
                    return Console.ReadLine();
                }
                catch (SyntaxErrorException err)
                {
                    Console.WriteLine(err.Message);
                }
        }

        public static void Wait()
        {
            InputString("Нажмите Enter для продолжения...");
        }

        public static bool IsNullOrEmpty<T>(Queue<T> queue)
        {
            if (IsNull(queue))
            {
                return true;
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("Очередь пуста");
                return true;
            }
            return false;
        }

        public static bool IsNull<T>(T collection)
        {
            if (collection == null)
            {
                Console.WriteLine("Коллекция не создана");
                return true;
            }
            return false;
        }

        public static bool IsNullOrEmpty<T,TK>(SortedDictionary<T,TK> collection)
        {
            if (IsNull((collection)))
            {
                return true;
            }
            else if (collection.Count == 0)
            {
                Console.WriteLine("Коллекция пуста");
                return true;
            }
            return false;
        }
        
        
        
        public static bool IsNull<T>(Queue<T> queue)
        {
            if (queue == null)
            {
                Console.WriteLine("Очередь не создана");
                return true;
            }
            return false;
        }

        public static int ChooseType(string invMsg = "Выберите тип объекта: ")
        {
            int k = 0;
            while (k > 3 || k < 1)
            {

                    
                Console.WriteLine("\tВыбор типа объекта:");
                Console.WriteLine("1. Рабочий");
                Console.WriteLine("2. Инженер");
                Console.WriteLine("3. Работник админестрации");
                Console.Write(invMsg);
                k = Tools.InputNumInt();
            }

            return k;
        }
        
        public static void SortWithComparer(ref List<Person> list, IComparer comparer)
        {
            Person[] a = list.ToArray();
            Array.Sort(a,comparer);
            list = a.ToList();

            Console.WriteLine("Список отсортирован");
        }
        
    }
    
    
}