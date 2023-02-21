using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string fileName = @"D:\KPI\input.txt";
        List<string> lines = new List<string>();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        List<string> uniqueLines = new List<string>();
        foreach (string line in lines)
        {
            if (!uniqueLines.Contains(line))
            {
                uniqueLines.Add(line);
            }
        }
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (string line in uniqueLines)
            {
                writer.WriteLine(line);
            }
        }
        Console.WriteLine("Same lines were deleted.");
    }
}
