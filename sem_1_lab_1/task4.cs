using System;
namespace task4
{
    class Programm
    {
        public static void Main(String[] args)
        {
         /*// test scenarios
         x=2; a=6
         result: res=0.9092974278256817
         x=3; a=10
         result: res=0.1411200080598672
         x=4; a=2
         result: res=-0.7568024953079282
         x=12; a=11
         result: res=-0.53657291800004349
         x=-8; a=4
         result: res=-0.9893582466233818
         x=5; a=2
         result: res=-0.9589242746631385
         */
            Console.Write("Enter x: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Math.Sin(x));
            double res = 0;
            double x1 = x;
            if (x > Math.PI)
            {
                while (x > Math.PI)
                    x -= Math.PI;
            }
            else if (x < -Math.PI)
            {
                while (x < -Math.PI)

                    x += Math.PI;
            }
            if (x1 > 2 * Math.PI)
            {
                while (x1 > 2 * Math.PI)
                    x1 -= 2 * Math.PI;

            }
            else if (x1 < -2 * Math.PI)
            {
                while (x1 < -2 * Math.PI)

                    x1 += 2 * Math.PI;
            }
            for (double i = 0; i <= a; i++)
            {
                double f = 1;
                for (double i1 = 2; i1 <= 2 * i + 1; i1++)
                {
                    f *= i1;
                }
                res += Math.Pow(-1, i) * (Math.Pow(x, 2 * i + 1)) / (f);
            }
            if (0 <= x1 && x1 <= Math.PI && res < 0)
            {
                res = -1 * res;
            }
            else if (x1 < 0 || x1 > Math.PI)
            {
                res = -1 * res;
            }
            Console.WriteLine("Sin(x) = " + res);
        }
    }
}
