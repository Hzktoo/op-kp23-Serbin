using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "D:\\KPI\\OP\\myFile.txt";
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("This is the first line");
            writer.WriteLine("This is the second line");
        }
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}

