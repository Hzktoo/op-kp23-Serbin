using System;

namespace Hometask4;
public class Program
{
    static void Main()
    {
        int n;
        while (true)
        {
            Console.WriteLine("Enter the number 1 to 9: ");
            n = Convert.ToInt16(Console.ReadLine());
            if (n > 9 || n < 1)
            {
                Console.WriteLine("False number!");
                continue;
            }
            for (int a = 0; a < n; a++)
            {
                int y = 1;
                for (int p = 0; p < n - a; p++)
                {
                    Console.Write("   ");
                }

                for (int x = 0; x <= a; x++)
                {
                    Console.Write("   {0:D} ", y);
                    y = y * (a - x) / (x + 1);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}