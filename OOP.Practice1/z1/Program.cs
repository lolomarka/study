using System;

namespace Z1
{
	class Z1
	{
		private static int n, m;
		static void Main(string[] args)
		{
			string buf;
			bool ok;
			do
			{
				Console.Write("n? ");
				buf = Console.ReadLine();
				ok = int.TryParse(buf, out n);
				if (!ok) Console.WriteLine("Введите целое число");
			} while (!ok);

			do
			{
				Console.Write("m? ");
				buf = Console.ReadLine();
				ok = int.TryParse(buf, out m);
				if (!ok) Console.WriteLine("Введите целое число");
				if(m == 1) {Console.WriteLine("Ошибка.m = 1 недопустимо!"); ok = false;}
			} while (!ok);
			Func1();
			Func2();
			Func3();
			Func4();
		}
		static void Func1()
		{
			int res1 = (n++ / --m);
			res1++;
			Console.WriteLine($"(n++/--m)++ = {res1}, после операции: n = {n}, m = {m}");
			NextCommand();
		}
		static void Func2()
		{
			bool res2 = ++m < n--;
			Console.WriteLine($"++m<n-- = {res2}, после операции: n = {n}, m = {m}");
			NextCommand();
		}
		static void Func3()
		{
			bool res3 = --m > ++n;
			Console.WriteLine($"--m > ++n = {res3}, после операции: n = {n}, m = {m}");
			NextCommand();
		}
		static void Func4()
		{
			bool ok;
			string buf;
			double x;
			do
			{
				Console.Write("x? ");
				buf = Console.ReadLine();
				ok = double.TryParse(buf, out x);
				if (!ok) Console.WriteLine("Введите число");
			} while (!ok);
			double k = Math.Pow(x,2);

			float res4 = 7 * (float)Math.Atan(k);
			Console.WriteLine($"arctan(x^2) = {res4}");

			NextCommand();
		}
		static void NextCommand()
		{
		Console.WriteLine("Press any key to continue");
		Console.ReadKey();
		}
	}
}