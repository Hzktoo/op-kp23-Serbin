using System;

namespace HomeworkTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            int c;
            Console.WriteLine("Enter value for a");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter value for b");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter value for c");
            c = Convert.ToInt32(Console.ReadLine());
            if (a > 0)
            {
                if (b > 0)
                {
                    if (c > 0)
                    {
                        double d = (a + b + c) / 2;
                        double d1 = Math.Sqrt(d * (d - a) * (d - c) * (d - b));
                        Console.WriteLine("Area of ​​a triangle according to Heron's formula:" + d1);
                    }
                    else
                    {
                        Console.WriteLine("The number c must be positive");
                    }
                }
                else
                {
                    Console.WriteLine("The number b must be positive");
                }
            }
            else
            {
                Console.WriteLine("The number a must be positive");
            }



        }
    }
}

