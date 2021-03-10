using System;
using System.Collections.Generic;
using System.Text;

namespace L12
{
    public class ColorPrint
    {
        public static void Print(object obj, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(obj);
            Console.ResetColor();
        }

        public static void Error(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(obj);
            Console.ResetColor();
        }

        public static void Success(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(obj);
            Console.ResetColor();
        }
    }
}