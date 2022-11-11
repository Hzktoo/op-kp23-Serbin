using System;
namespace task3
{
    class Programm
    {
        public static void Main(String[] args)
        {
            /*// test scenarios
            n=2; x=3
            result: res1=2; res2=9;
            n=5; x=2
            result: res1=120; res2=32;
            n=6; x=10
            result: res1=720; res2=1000000;
            n=12; x=14
            result: res1=479001600; res2=344068096
            */
            Console.WriteLine("Enter a number n");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a number x");
            int x = Convert.ToInt32(Console.ReadLine()); 
            int res1 = 1;
            int res2 = 1;
            for (int i = 1; n >= i; ++i)
            {
                res1 = res1 * i;
            }
            Console.WriteLine("factorial of number " + n + " is " + res1);
            for (int i = 1; i <= n; i++)
            {
                res2 *= x;
            }
            Console.WriteLine("The number " + x + " rased to the power "+ n + " is " + res2);
        }
    }
}
