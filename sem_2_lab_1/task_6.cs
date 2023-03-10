using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.AccessControl;
using System.Text;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            const string PATH_TO_CSV = "D:\\KPI\\Studentss.csv";
            const string NAME_OF_FIRST_BINARY_FILE = "Students.dat";
            const string NAME_OF_SECOND_BINARY_FILE = "ExcellentStudents.dat";

            List<string> students = ReadCSVFile(PATH_TO_CSV);
            WriteBinaryFile(NAME_OF_FIRST_BINARY_FILE, students);
            FindExcellentStudents(NAME_OF_FIRST_BINARY_FILE, NAME_OF_SECOND_BINARY_FILE, students);
        }
        static List<string> ReadCSVFile(string path)
        {
            List<string> students = new List<string>();
            string line;
            return students;
        }
        static void WriteBinaryFile(string binaryFileName, List<string> list)
        {
            writer.Write(list[i]);
        }
        static void FindExcellentStudents(string studentsFileName, string excellentStudentsFileName, List<string> students)
        {
            string str;
            List<string> excellentStudents = new List<string>();
        }
    }
}