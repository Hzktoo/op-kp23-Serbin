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
            /*
    Test scenariouses
    Test 1:
    Input:
    First name 1	Last name 1	75
    First name 2	Last name 2	24
    First name 3	Last name 3	60
    First name 4	Last name 4	100
    First name 5	Last name 5	89
    First name 6	Last name 6	50
    First name 7	Last name 7	0
    First name 8	Last name 8	19
    First name 9	Last name 9	45
    First name 10	Last name 10 71
    Output:
    First name 4	Last name 4	100
    Test 2:
    Input: 
    First name 1	Last name 1	75
    First name 2	Last name 2	61
    First name 3	Last name 3	60
    First name 4	Last name 4	100
    First name 5	Last name 5	89
    First name 6	Last name 6	99
    First name 7	Last name 7	67
    First name 8	Last name 8	84
    First name 9	Last name 9	100
    First name 10	Last name 10 71
    Output:
    First name 4	Last name 4	100
    First name 6	Last name 6	99
    First name 9	Last name 9	100
    */
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
            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();

                while (line != null)
                {
                    students.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ecxeption" + ex.Message);
            }

            return students;
        }
        static void WriteBinaryFile(string binaryFileName, List<string> list)
        {
            using (var stream = File.Open(binaryFileName, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        writer.Write(list[i]);
                    }
                }
            }
        }
        static void FindExcellentStudents(string studentsFileName, string excellentStudentsFileName, List<string> students)
        {
            string str;
            List<string> excellentStudents = new List<string>();

            if (File.Exists(studentsFileName))
            {
                using (var stream = File.Open(studentsFileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        for (int i = 0; i < students.Count; i++)
                        {
                            string student = reader.ReadString();
                            string[] studentInfo = student.Split(';');

                            if (int.Parse(studentInfo[^1]) >= 95)
                                excellentStudents.Add(student);
                        }
                    }
                }
            }
            using (var stream = File.Open(excellentStudentsFileName, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    for (int i = 0; i < excellentStudents.Count; i++)
                    {
                        writer.Write(excellentStudents[i]);
                    }
                }
            }
        }
    }
}
