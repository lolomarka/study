using System;

namespace OOPlab9
{
    public class Triangle
    {
        //Поля класса
        private double a = 0;
        private double b = 0;
        private double c = 0;

        static private int instance = 0;



        //Конструкторы
        public Triangle() { a = 0.0; b = 0.0; c = 0.0; instance++;}
        public Triangle(double A, double B, double C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            instance++;
        }

        //Деструктор
        ~Triangle()
        {
            this.Instance = this.Instance - 1;
        }
        
        //Свойства
        public double A
        {
            get
            {
                return a;
            }
            set
            {
                if(value >= 0)
                    this.a = value;
                // else
                //     this.a = 0;
            }
        }

        public double B
        {
            get
            {
                return b;
            }
            set
            {
                if(value >= 0)
                    this.b = value;
                // else
                //     this.b = 0;
            }
        }

        public double C
        {
            get
            {
                return c;
            }
            set
            {
                if(value >= 0)
                    this.c = value;
                // else
                //     this.c = 0;
            }
        }

        public int Instance
        {
            get
            {
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        // public double AreaOfTriangle
        // {
        //     get
        //     {
        //         double p = (a + b + c)/2;
        //         double s = Math.Sqrt(p*(p-a) * (p-b) * (p-c));

        //         return s;
        //     }
        // }

        //Методы

        public void SetInstanceToZero()
        {
            Instance = 0;
        }



        public string GetInformationToString
        {
            get
            {
                return $"Длины катетов:\nA = {Math.Round(this.A,3)};\nB = {Math.Round(this.B,3)};\nC = {Math.Round(this.C,3)};\nЭкземпляров класса создано: {this.Instance}.\nПлощадь равна: {this.AreaOfTriangleToString()}\n";
            }
        }

        public double AreaOfTriangle()
        {
            double p = (a + b + c)/2;
            double s = Math.Sqrt(p*(p-a)*(p-b)*(p-c));

            return s;
        }

        //Вернуть private после тестов
        public string AreaOfTriangleToString()
        {
            double result = this.AreaOfTriangle();
            return double.IsNaN(result) ? "0" : result.ToString();
        }

        //
        //Перегрузка операторов
        //

        //Унарные
        // static public Triangle operator++(Triangle t1)
        // {
        //     return new Triangle(t1.A + 1.0, t1.B + 1.0, t1.C + 1.0);
        // }

        // static public Triangle operator--(Triangle t1)
        // {
        //    return new Triangle(t1.A - 1.0, t1.B - 1.0, t1.C - 1.0);
        // }

        static public Triangle operator++(Triangle t1)
        {
            t1.A += 1.0;
            t1.B += 1.0;
            t1.C += 1.0;
            return t1;
        }

        static public Triangle operator--(Triangle t1)
        {
            t1.A -= 1.0;
            t1.B -= 1.0;
            t1.C -= 1.0;
            return t1;
        }

        //
        //Перегрузка преобразования типов
        //


        //Явная
        static public explicit operator double(Triangle param)
        {
            if(param.AreaOfTriangle() <= 0)
                return -1;                              //Треугольник не существует - отрицательное число
            else
                return param.AreaOfTriangle();          //Треугольник существует - площадь треугольника
        }


        static public implicit operator bool(Triangle param)
        {
            if(param.AreaOfTriangle() > 0)
                return true;
            else
                return false;
        }


        //
        //Перегрузка бинарных операций
        //


        static public bool operator>=(Triangle t1, Triangle t2)
        {
            if(t1.AreaOfTriangle() >= t2.AreaOfTriangle())
                return true;
            else
                return false;
        }

        static public bool operator<=(Triangle t1, Triangle t2)
        {
            if(t1.AreaOfTriangle() <= t2.AreaOfTriangle())
                return true;
            else
                return false;
        }

        static public bool operator>(Triangle t1, Triangle t2)
        {
            if(t1.AreaOfTriangle() > t2.AreaOfTriangle())
                return true;
            else
                return false;
        }

        static public bool operator<(Triangle t1, Triangle t2)
        {
            if(t1.AreaOfTriangle() < t2.AreaOfTriangle())
                return true;
            else
                return false;
        }
        
    }
}
