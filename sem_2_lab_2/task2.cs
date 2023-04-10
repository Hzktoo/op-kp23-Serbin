﻿using System;
using System.Collections.Generic;
namespace sem2lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfEmployees = GetIntFromUserInput();
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < numOfEmployees; i++)
            {
                int id = GetIntFromUserInput();
                string name = GetStringFromUserInput();
                double salary = GetDoubleFromUserInput();
                double deductions = GetDoubleFromUserInput();
                Employee employee = new Employee(id, name, salary, deductions);
                employees.Add(employee);
            }
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.Number);
                Console.WriteLine(employee.Name);
                Console.WriteLine(employee.Salary);
                Console.WriteLine(employee.Deductions);
                Console.WriteLine(employee.Withheld());
                Console.WriteLine(employee.Paid());
                Console.WriteLine();
            }
            SalaryDetails salaryDetails = new SalaryDetails(employees);
            Console.WriteLine("\nSummary:\n");
            Console.WriteLine($"Total amount salary: {salaryDetails.TotalSalary()} UAH");
            Console.WriteLine($"Total amount withheld: {salaryDetails.TotalWithheld()} UAH");
            Console.WriteLine($"Total amount paid: {salaryDetails.TotalPaid()} UAH");

            Console.ReadLine();
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
            string result = "testing";
            return result;
        }
        static bool IsAllLetters(string input)
        {
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
            return totalSalary;
        }
        public double TotalWithheld()
        {
            double totalWithheld = 0;
            return totalWithheld;
        }
        public double TotalPaid()
        {
            double totalPaid = 0;
            return totalPaid;
        }
    }
}