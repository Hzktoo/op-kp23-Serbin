using System;
using System.IO;
using System.Runtime.CompilerServices;
namespace Task1
{
    class Program
    {
        /*test scenarioses
     Input: -
     Output: "First line"
    "Second Line"
     */
        static void Main(string[] args)
        {
            string folder = "D:\\KPI\\Programming\\";
            string fileName = "Input.txt";
            SaveTextToFile(folder, fileName);
            LoadTextFromFile(folder, fileName);
        }
        static void SaveTextToFile(string folder, string fileName)
        {
            folder += fileName;
            StreamWriter writedline = new StreamWriter(folder);
        }
        static void LoadTextFromFile(string folder, string fileName)
        {
            folder += fileName;
            string line;
            StreamReader writedline = new StreamReader(folder);
        }
    }
}
