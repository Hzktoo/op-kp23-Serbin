using System;

namespace HomeworkTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1;
            int y1;
            int x2;
            int y2;
            Console.WriteLine("Enter value for x1");
            x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter value for y1");
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter value for x2");
            x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter value for y2");
            y2 = Convert.ToInt32(Console.ReadLine());
            double a = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            Console.WriteLine("The modulus of the vector is equal to " + a);
        }
    }
 

}
