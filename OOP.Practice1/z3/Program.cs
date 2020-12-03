using System;

namespace Z3
{
	class Z3
	{
		static void Main(string[] args)
		{
			Func1();
			Func2();
		}
		static void Func1()
		{
			int a = 1000;
			float b = 0.0001f;

			float r1 = (float)Math.Pow(a + b, 2);
			float r2 = (float)Math.Pow(a,2)+ 2*a*b;
			float r3 = (float)Math.Pow(b,2);
			float r4 = r1 - r2;
			float r = r4/r3;

			Console.WriteLine("Тип float - " + r);
		}
		static void Func2()
		{
			int a = 1000;
			double b = 0.0001;
		
			double r1 = Math.Pow(a + b, 2);
			double r2 = Math.Pow(a,2)+ 2*a*b;
			double r3 = Math.Pow(b,2);
			double r4 = r1 - r2;
			double r = r4/r3;
			Console.WriteLine("Тип double - " + r);
		}
	}
}