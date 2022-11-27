using System;
namespace task2
{
    class Programm
    {
        public static void Main(String[] args)
        {
         /*// test scenarios
         n=3
         result: number n is prime;
         n=18
         result: number n is not prime;
         n=-643
         result: number n is not prime;
         n=248
         result: number n is not prime;
         n=347
         result: number n is prime.
         */
            int n;
            Console.WriteLine("Enter the number n:");
            n = Convert.ToInt32(Console.ReadLine());
            if (n > 1)
            {
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        Console.WriteLine("number n is not prime");
                        return;
                    }
            
                }
                Console.WriteLine("number n is prime");
            }
            else
            {
                Console.WriteLine("number n is not prime");
            }
        }
    }
}
