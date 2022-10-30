using System;
class program
{
    static public void Main(string[] args)
    {
        int n=Convert.ToInt32(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            string x = "";
            string y = "";

            for(int j = 0; j < i*4; j++)
            {
               x+=".";
            }
            for (int j = (n-i-2)*2 ; j >= 0; j --)
            {
                y += " ";
            }
            Console.Write(y + "|<>");
            Console.WriteLine(x+"<>|");
        }
        for (int i =n-1; i>=0; i--)
        {
            string x1 = "";
            string y1 = "";
            for (int j = 0; j < i * 4; j++)
            {
                x1 += ".";
            }
            for (int j = 0; j <=(n - i - 2) * 2; j++)
            {
                y1 += " ";
            }
            Console.Write(y1 + "|<>");
            Console.WriteLine(x1 + "<>|");
        }
    }
}
