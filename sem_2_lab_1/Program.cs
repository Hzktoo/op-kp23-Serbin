using System;
using System.IO;
using System.Linq;
class Program
{
    static void Main()
    {
        string inputFile;
        string outputFile;
        string[] lines = File.ReadAllLines(inputFile);
        File.WriteAllLines(outputFile, lines);
    }
}