using System;
using System.IO;
using System.Linq;

class Program
{
       /*
     Test scenariouses
     Test 1:
     Input: yes
            no
            KPI
            whynotoke
            please
            go
            within
            computer
            programing
     Output: computer
            go 
            KPI
            no
            please
            programing
            whynotoke
            within
            yes
     Test 2:
     Input:  yes
             no
             KPI
             whynotoke
             please
             go away
             within
             computer
             programing
     Output: Error: line contains more than one word
     
     */
    static void Main()
    {
        string inputFile = @"D:\KPI\Programming\Englishwords.txt";
        string outputFile = @"D:\KPI\Programming\SortedWords.txt";
        string[] lines = File.ReadAllLines(inputFile);
        File.WriteAllLines(outputFile, lines);
    }
}
