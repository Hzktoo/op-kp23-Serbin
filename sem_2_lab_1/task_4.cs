using System;
using System.IO;

namespace Task4
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
     First name 2	Last name 2	24
     First name 6	Last name 6	50
     First name 7	Last name 7	0
     First name 8	Last name 8	19
     First name 9	Last name 9	45;
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
     There is no bad students
     */
static void Main(string[] args)
        {
            const string PATH = "D:\\KPI\\students.csv";
            List<string> students = ReadCSVFile(PATH);
            List<string> badStudents = SearchBadStudents(students);
            if (badStudents.Count == 0)
            {
                Console.WriteLine("There are no bad students!");
            }
            else
            {
                foreach (var badStudent in badStudents)
                {
                    Console.WriteLine(badStudent);
                }
            }
        }
        static List<string> SplitLine(string line, char spliter)
        {
            List<string> numbers = new List<string>();
            int step = 0;
            string number = "";
            while (step < line.Length)
            {
                if (line[step] == spliter)
                {
                    numbers.Add(number);
                    number = "";
                    step++;
                }
                number += line[step];
                step++;
            }
            numbers.Add(number);
            return numbers;
        }
        static List<string> ReadCSVFile(string path)
        {
            List<string> strings = new List<string>();
            string line;
            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();

                while (line != null)
                {
                    strings.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception" + ex.Message);
            }

            return strings;
        }
        static List<string> SearchBadStudents(List<string> students)
        {
            List<string> badStudents = new List<string>();
            for (int i = 0; i < students.Count; i++)
            {
                List<string> studentInfo = SplitLine(students[i], ';');
                
                if (int.Parse(studentInfo[^1]) < 60)
                {
                    string temp = "";
                    for (int j = 0; j < studentInfo.Count; j++)
                    {
                        if (j != studentInfo.Count - 1)
                        {
                            temp += studentInfo[j] + ", ";
                        }
                        else
                        {
                            temp += studentInfo[j];
                        }
                    }
                    badStudents.Add(temp);
                }
            }
            return badStudents;
        }    


    }
}
