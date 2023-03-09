using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        string input;
        string[] numbers = input.Split(' ');
        string filePath = @"D:\KPI\Programming\random_numbers.txt";
        StreamWriter writer = new StreamWriter(filePath);
        double maxNumber = double.MinValue;
        string maxFilePath = @"D:\KPI\Programming\max.txt";
        StreamWriter maxWriter = new StreamWriter(maxFilePath);
    }
}