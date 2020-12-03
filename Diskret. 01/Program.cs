using System;
using System.Collections.Generic;
using System.Linq;


namespace LogicalCalculator
{
    class Program
    {
        static int n;
        static List<int> U, A, B, C, D;
        static IEnumerable<int> mult1, mult2;
        static void Main(string[] args)
        {
            Run();
        }
        static void Run()
        {
            InputU();
            InputNumA();
            InputNumB();
            InputNumC();
            InputNumD();
            Brackets();
        }
        static IEnumerable<int> Parse(string str)
        {
            bool flag, neg1, neg2, inter, un;
            flag = neg1 = neg2 = inter = un = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 && (str[i] == '!' || str[i] == '-')) neg1 = true;
                else if (i != 0 && (str[i] == '!' || str[i] == '-')) neg2 = true;
                else if (str[i] == 'A' || str[i] == 'a')
                    if (flag == false)
                    {
                        mult1 = A;
                        flag = true;
                    }
                    else mult2 = A;
                else if (str[i] == 'B' || str[i] == 'b')
                    if (flag == false)
                    {
                        mult1 = B;
                        flag = true;
                    }
                    else mult2 = B;
                else if (str[i] == 'C' || str[i] == 'c')
                    if (flag == false)
                    {
                        mult1 = C;
                        flag = true;
                    }
                    else mult2 = C;
                else if (str[i] == 'D' || str[i] == 'd')
                    if (flag == false)
                    {
                        mult1 = D;
                        flag = true;
                    }
                    else mult2 = D;
                else if (str[i] == '^') inter = true;
                else if (str[i] == 'v') un = true;
            }
            if (neg1 == true)
            {
                mult1 = Exception(mult1);
                if (inter == false && un == false)
                    return mult1;
            }
            if (neg2 == true)
            {
                mult2 = Exception(mult2);
                if (inter == false && un == false)
                    return mult2;
            }
            if (inter == true) return (Intersection(mult1, mult2));
            if (un == true) return (Union(mult1, mult2));
            return mult1;
        }
       
        static IEnumerable<int> Intersection(IEnumerable<int> a, IEnumerable<int> b)
        {
            return a.Intersect(b);
        }
        static IEnumerable<int> Union(IEnumerable<int> a, IEnumerable<int> b)
        {
            return a.Union(b);
        }

         static IEnumerable<int> Exception(IEnumerable<int> a)
        {
            return U.Except(a);
        }
        static void InputU()
        {
            Console.Write("Количество элементов в универсуме: ");
            n = Convert.ToInt32(Console.ReadLine());
            U = new List<int>(n);
            for (int i = 1; i <= n; i++)
            {
                U.Add(i);
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
        }
        static void InputNumA()
        {
            Console.Write("Количество элементов в A: ");
            n = Convert.ToInt32(Console.ReadLine());
            A = new List<int>(n);
            for (int i = 0; i < n; i++)
                A.Add(Convert.ToInt32(Console.ReadLine()));
        }
        static void InputNumB()
        {
            Console.Write("Количество элементов в B: ");
            n = Convert.ToInt32(Console.ReadLine());
            B = new List<int>(n);
            for (int i = 0; i < n; i++)
                B.Add(Convert.ToInt32(Console.ReadLine()));
        }
        static void InputNumC()
        {
            Console.Write("Количество элементов в C: ");
            n = Convert.ToInt32(Console.ReadLine());
            C = new List<int>(n);
            for (int i = 0; i < n; i++)
                C.Add(Convert.ToInt32(Console.ReadLine()));
        }
        static void InputNumD()
        {
            Console.Write("Количество элементов в D: ");
            n = Convert.ToInt32(Console.ReadLine());
            D = new List<int>(n);
            for (int i = 0; i < n; i++)
                B.Add(Convert.ToInt32(Console.ReadLine()));
        }
        static void Brackets()
        {
            Console.Write("Количество скобок: ");
            n = Convert.ToInt32(Console.ReadLine());
            IEnumerable<int>[] Brackets = new IEnumerable<int> [n];
            for (int i = 0; i < Brackets.Length; i++)
            {
                Console.Write("Скобка({0}): ", i+1);
                string st = Console.ReadLine();
                Brackets[i] = Parse(st);
            }
            if (n != 1)
            {
                Console.Write("Операция между скобками: ");
                string buf = Console.ReadLine();
                if (buf == "^" || buf == "*")
                    for (int i = 0; i < (Brackets.Length - 1); i++)
                        Brackets[i + 1] = Intersection(Brackets[i], Brackets[i + 1]);
                if (buf == "v" || buf == "+")
                    for (int i = 0; i < (Brackets.Length - 1); i++)
                        Brackets[i + 1] = Union(Brackets[i], Brackets[i + 1]);
            }
            Console.Write("Ответ: ");
            foreach (int element in Brackets[n - 1])
                Console.Write($"{element} ");
        }
    }
}
