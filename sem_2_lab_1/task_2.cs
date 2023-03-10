using System;
using System.IO;
class Program
{
    /*
    Test scenariouses
    Test 1:
    input: 2, 10, 32, 24, 5, 8, 198, 64, 12, 43, 12, 15, 13, 76, 32
    Output: 2, 10, 32, 24, 5, 8, 198, 64, 12, 43, 12, 15, 13, 76, 32
            max: 198;
    Test 2: 
    Input: 2, 10, 32, 24, 5, 8, 198, 64, 12, 43, 12, 15, 13, 76
    Output: Error: you must enter exactly 15 numbers;
    Test 3:
    Input: 3, 6, 8, 10, 12, 14, 16, 20, 46, 72, 11, 8, 5, 65, 42
    Output: 3, 6, 8, 10, 12, 14, 16, 20, 46, 72, 11, 8, 5, 65, 42
            max: 72
    */
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
