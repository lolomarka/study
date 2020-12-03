using System;
namespace OOPPractice9
{
    class TriangleArray
    {
        //
        //!Сменить степень защиты после тестов
        public Triangle[] arr;
        public int length;

        
        public TriangleArray()
        {
            arr = new Triangle[0];
            length = 0;
        }

        public TriangleArray(int Length, ref Random rnd)
        {
            arr = new Triangle[Length];
            length = Length;

            for (int i = 0; i < Length; i++)
            {
                double a,b,c;
                a = Math.Abs((double)rnd.Next(64,255) / (double)rnd.Next(1,32));
                b = Math.Abs((double)rnd.Next(64,255) / (double)rnd.Next(1,32));
                c = Math.Sqrt(Math.Pow(a,2) + Math.Pow(b,2));
                arr[i] = new Triangle(a,b,c);
            }
        }

        public void AddLast(Triangle tri)
        {
            var buff = new Triangle[length + 1];
            length += 1;

            for(int i = 0; i < this.arr.Length; i++)
            {
                buff[i] = arr[i];
            }
            buff[length-1] = tri;

            this.arr = buff;
        }

        public TriangleArray(int Length)
        {
            Console.WriteLine("\tИнициализация массива: ");
            length = Length;
            arr = new Triangle[Length];

            for (int i = 0; i < length; i++)
            {
                try
                {
                    Console.WriteLine($"Введите A,B,C для элемента №{i+1}");

                    double a,b,c;
                    a = Program.InputAbsNumDouble();
                    b = Program.InputAbsNumDouble();
                    c = Program.InputAbsNumDouble();
                    arr[i] = new Triangle(a,b,c);
                }
                catch(Exception err)
                {
                    Console.WriteLine("Ошибка! "+ err.Message);
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                }
            }
        }

        public Triangle this [int index]
            {
                get
                {
                    return arr[index];
                }
                set
                {
                    arr[index] = value;
                }
            }
        
        public string Show()
        {
            string str = "";

            for (int i = 0; i < length; i++)
            {
                str += $"Элемент №{i+1}:\n{arr[i].GetInformationToString}\t";
            }

            return str;
        }

        public int GetMinimalTriangle()
        {
            return FindMinimalArea();
        }

        private int FindMinimalArea()
        {
            double Max = double.MaxValue;
            int index = 0;
            for(int i = 0; i < length; i++)
            {
                if(Max > arr[i].AreaOfTriangle())
                {
                    Max = arr[i].AreaOfTriangle();
                    index = i;
                }
                
            }

            return index;
        }

    }
}