using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string inputFile = @"D:\KPI\Programming\Englishwords.txt";
        string outputFile = @"D:\KPI\Programming\SortedWords.txt";
        string[] lines = File.ReadAllLines(inputFile);
        File.WriteAllLines(outputFile, lines);
    }
}