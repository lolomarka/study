using System;

namespace Z2
{
	class Z2
	{
		static void Main(string[] args)
		{
			string buf;
			bool ok;
			double x, y;
			do
			{
				Console.Write("x? ");
				buf = Console.ReadLine();
				ok = double.TryParse(buf, out x);
				if (!ok) Console.WriteLine("Введите число");
			} while (!ok);
			do
			{
				Console.Write("y? ");
				buf = Console.ReadLine();
				ok = double.TryParse(buf, out y);
				if (!ok) Console.WriteLine("Введите число");
			} while (!ok);

			bool f1 = (x >= 0) && ((-x + 5) >= y) && ((x - 5) <= y);
			bool f2 = (x <= 0) && (-x - 5 <= y) && (y <=0);
			bool isInhere = (f1) || (f2);
			Console.WriteLine("Большой треугольник - " + f1);
			Console.WriteLine("Малый треугольник - " + f2);
			Console.WriteLine("Входит в область - " + isInhere);

			}
		}
}
