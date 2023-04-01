using System;

namespace SalaryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Salary Management System!\n");

            Console.Write("Enter the number of employees: ");
            int numEmployees = Convert.ToInt32(Console.ReadLine());
            Employee[] employees = new Employee[numEmployees];
            Console.WriteLine("\nSalary Details:\n");
            Console.WriteLine("\nSummary:\n"); 
        }
        static int GetIntFromUserInput()
        {
            int result = 0;
            return result;
        }

        static double GetDoubleFromUserInput()
        {
            double result = 0;
            return result;
        }

        static string GetStringFromUserInput()
        {
            string result = "starting";
            return result;
        }

        static bool IsAllLetters(string input)
        {
            return true;
        }
    }
    class Employee
    {
        private int _id;
        private string _name;
        private double _salary;
        private double _deductions;
        public Employee(int id, string name, double salary, double deductions)
        {
            _id = id;
            _name = name;
            _salary = salary;
            _deductions = deductions;
        }
        public int Id
        {
            get { return _id; }
        }
        public string Name
        {
            get { return _name; }
        }
        public double Salary
        {
            get { return _salary; }
        }
        public double Deductions
        {
            get { return _deductions; }
        }
        public double Withheld()
        {
            return _salary * _deductions;
        }
        public double Paid()
        {
            return _salary - Withheld();
        }
        public static double TotalWithheld(Employee[] employees)
        {
            double totalWithheld = 0;
            return totalWithheld;
        }
        public static double TotalPaid(Employee[] employees)
        {
            double totalPaid = 0;
            return totalPaid;
        }
    }
}
