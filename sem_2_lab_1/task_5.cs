using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
        /*
     Test scenariouses:
    Test 1:
    Input:
    why yes why no let's do this
    Output: 
    do: 1
    let's: 1
    no: 1
    this: 1
    why: 2
    yes: 1;
    Test 2: 
    Input:
    computer computer computer computer
    Output:
    computer: 4
     */
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
