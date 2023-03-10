using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string PATH = "D:\\KPI\\students.csv";
            List<string> students = ReadCSVFile(PATH);
            List<string> badStudents = SearchBadStudents(students);
        }
        static List<string> SplitLine(string line, char spliter)
        {
            List<string> numbers = new List<string>();
            int step = 0;
            string number = "";
            return numbers;
        }

        static List<string> ReadCSVFile(string path)
        {
            List<string> strings = new List<string>();
            string line;
            return strings;
        }
        static List<string> SearchBadStudents(List<string> students)
        {
            List<string> badStudents = new List<string>();
            return badStudents;
        }


    }
}