using System;
using System.Collections.Generic;
namespace sem2lab2
{
    class Program
    {
        /*
         Test scenariouses
        Test 1:
        Input: 2; 1; Artem; 1000; 0,15; 2; Bogdan; 1200; 0,15
        Output: Total amount salary: 2200 UAH;
        Total amount witheld: 330 UAH;
        Total amount paid: 1870 UAH;
        Test 2: 
        Input: 3; 1; Dmytro; 13000; 0,2; 2; Vasyliy; 12500; 0,18; 3; Genry; 14200; 0,22; 
        Output: Total amount salary: 39700 UAH;
        Total amount witheld: 7974 UAH;
        Total amount paid: 31726 UAH;
        Test 3:
        Input: 2; 1; 200; 10000; fff;
        Output: Invalid input;
         */
static void Main(string[] args)
        {
            Console.WriteLine("Salary Management System\n");

            Console.Write("Enter the number of employees: ");
            int numOfEmployees = GetIntFromUserInput();

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < numOfEmployees; i++)
            {
                Console.WriteLine($"\nEnter details for employee {i + 1}");

                Console.Write("Employee number: ");
                int id = GetIntFromUserInput();

                Console.Write("Employee name: ");
                string name = GetStringFromUserInput();

                Console.Write("Salary: ");
                double salary = GetDoubleFromUserInput();

                Console.Write("Deductions: ");
                double deductions = GetDoubleFromUserInput();

                Employee employee = new Employee(id, name, salary, deductions);
                employees.Add(employee);
            }

            Console.WriteLine("\nSalary Details:\n");

            foreach (Employee employee in employees)
            {
                Console.WriteLine($"Employee ID: {employee.Number}");
                Console.WriteLine($"Employee name: {employee.Name}");
                Console.WriteLine($"Salary: {employee.Salary} UAH");
                Console.WriteLine($"Deductions: {employee.Deductions}");
                Console.WriteLine($"Amount withheld: {employee.Withheld()} UAH");
                Console.WriteLine($"Amount paid: {employee.Paid()} UAH");
                Console.WriteLine();
            }

            SalaryDetails salaryDetails = new(employees);
            Console.WriteLine("\nSummary:\n");
            Console.WriteLine($"Total amount salary: {salaryDetails.TotalSalary()} UAH");
            Console.WriteLine($"Total amount withheld: {salaryDetails.TotalWithheld()} UAH");
            Console.WriteLine($"Total amount paid: {salaryDetails.TotalPaid()} UAH");

            Console.ReadLine();
        }

        static int GetIntFromUserInput()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            return result;
        }

        static double GetDoubleFromUserInput()
        {
            double result;
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            return result;
        }

        static string GetStringFromUserInput()
        {
            string result;
            while (string.IsNullOrWhiteSpace(result = Console.ReadLine()) || !IsAllLetters(result))
            {
                Console.WriteLine("Invalid input. Please enter a valid name.");
            }
            return result;
        }

        static bool IsAllLetters(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
    }

    class Employee
    {
        private int _number;
        private string _name;
        private double _salary;
        private double _deductions;

        public Employee(int number, string name, double salary, double deductions)
        {
            _number = number;
            _name = name;
            _salary = salary;
            _deductions = deductions;
        }

        public int Number
        {
            get { return _number; }
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
    }
    class SalaryDetails
    {
        private List<Employee> _employees;
        private List<Employee> employees;

        public SalaryDetails()
        {
            _employees = new List<Employee>();
        }

        public SalaryDetails(List<Employee> employees)
        {
            this.employees = employees;
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public double TotalSalary()
        {
            double totalSalary = 0;
            foreach (Employee employee in _employees)
            {
                totalSalary += employee.Salary;
            }
            return totalSalary;
        }

        public double TotalWithheld()
        {
            double totalWithheld = 0;
            foreach (Employee employee in _employees)
            {
                totalWithheld += employee.Withheld();
            }
            return totalWithheld;
        }

        public double TotalPaid()
        {
            double totalPaid = 0;
            foreach (Employee employee in _employees)
            {
                totalPaid += employee.Paid();
            }
            return totalPaid;
        }
    }
}
