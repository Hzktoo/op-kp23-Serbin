using System;

namespace HomeworkTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            int c;
            int d;
            Console.WriteLine("Enter value for a");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter value for b");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter value for c");
            c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter value for d");
            d = Convert.ToInt32(Console.ReadLine());
            if (a < b)
            {
                if (a < c)
                {
                    if (a < d)
                    {
                        Console.WriteLine("The least number is:" + a);
                    }
                    else
                    {
                        Console.WriteLine("The least number is:" + d);
                    }
                }
                else
                {
                    if (c < d)
                    {
                        Console.WriteLine("The least number is:" + c);
                    }
                    else
                    {
                        Console.WriteLine("The least number is:" + d);
                    }
                }
            }
            else
            {
                if (b < c)
                {
                    if (b < d)
                    {
                        Console.WriteLine("The least number is:" + b);
                    }
                    else
                    {
                        Console.WriteLine("The least number is:" + d);
                    }
                }
                else
                {
                    if (c < d)
                    {
                        Console.WriteLine("The least number is:" + c);
                    }
                    else
                    {
                        Console.WriteLine("The least number:" + d);
                    }
                }
            }
        }
    }
}
