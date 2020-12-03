using System;
namespace Lab3
{
    class Program
    {
        static double a = 0.1, b = 1.0;
        static double h, x, y, SN, SE;
        static void Main(string[] args)
        {
            Foo();        
        }
        static void Foo()
        {
            h = (b - a) / 10.0;
            for (x = a; x <= b; x += h)
            {
                y = Math.Exp(2*x);
                FunSE();
                FunSN();
                Console.WriteLine("X ={0: 0.0}   SN = {1:0.000}   SE = {2:0.000}   Y = {3:0.000}", x, SN, SE, y);
            }
        }
        static void FunSN()
        {
            SN = 1;
            double an = 1;
            double t;
            for (int n = 1; n <= 20; n++)
            {
                t = an;
                an = t * (2*x / (n));
                SN += an;
            }
        }
        static void FunSE()
        {
            SE = 1;
            double an = 1;
            double t;
            for (int n = 1; Math.Abs(an) > 0.001; n++)
            {
                t = an;
                an = t * (2*x / (n));
                SE += an;
            }
        }
    }
}