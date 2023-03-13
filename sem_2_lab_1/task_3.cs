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
        if (lines.Length > 40)
        {
            Console.WriteLine("Error: File contains more than 40 lines.");
            return;
        }
        foreach (string line in lines)
        {
            if (line.Split(' ').Length > 2)
            {
                Console.WriteLine("Error: Line contains more than one word.");
                return;
            }
            if (line.Length > 80)
            {
                Console.WriteLine("Error: Word exceeds 80 characters.");
                return;
            }
        }
        Array.Sort(lines);
        File.WriteAllLines(outputFile, lines);
        Console.WriteLine("Words sorted and written to file.");
    }
}
