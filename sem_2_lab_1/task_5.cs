using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = @"D:\KPI\Programming\calculating.txt";
        Dictionary<string, int> wordCounts = CountWordsInFile(filePath);
        PrintWordCounts(wordCounts);
        Console.ReadLine();
    }
    static Dictionary<string, int> CountWordsInFile(string filePath)
    {
        string fileContent = File.ReadAllText(filePath);
        string[] words = fileContent.Split(new[] { ' ', '\t', '\n', '\r' },
                                           StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        return wordCounts;
    }
    static void PrintWordCounts(Dictionary<string, int> wordCounts)
    {
 
    }
}