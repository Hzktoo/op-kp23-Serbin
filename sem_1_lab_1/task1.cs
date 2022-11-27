using System;
namespace task1
{
    class Programm
    {
        public static void Main(String[] args)
        {
            /*// test scenarios
        x0=5.3; xk=10.3; k=19
        result: y0=150.36584953882053; yk=1094.7762766061146;
        x0=2; xk=8; k=3
        result: y0=9.36267736213967; yk=514.3373327533212
        x0=14.3; xk=21.8; k=14
        result: y0=2926.1917649000143; yk=10362.093640265355
        x0=109; xk=1; k=54
        result: y0=1295030.754318801; yk=27.801649381175796
        */
            Console.WriteLine("Enter x0");
            double x0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter xk");
            double xk = Convert.ToDouble(Console.ReadLine());
            double a = 1.35, b = -6.25;
            double y;
            Console.WriteLine("Enter the number of intermediate values from x0 to xk");
            double k = Convert.ToDouble(Console.ReadLine());
            double dx = Math.Abs((xk - x0)) / ((k+2) - 1);
            if (x0 < xk)
            {
                for (double i = x0; i <= xk; i += dx)
                {
                    y = a + Math.Pow(i, 3) + Math.Pow(Math.Cos(Math.Pow(i, 3) - b), 2);
                    Console.WriteLine("x = "+ i + " y = " + y);
                }
            }
            else if (x0 > xk)
            {
                for (double i = x0; i >= xk; i -= dx)
                {
                    y = a + Math.Pow(i, 3) + Math.Pow(Math.Cos(Math.Pow(i, 3) - b), 2);
                    Console.WriteLine("x = " + i + " y = " + y);
                }
            }
        }
    }
}
