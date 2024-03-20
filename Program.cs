
using System;
using System.Collections.Generic;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public Employee(int id, string name, string department, double salary)
    {
        Id = id;
        Name = name;
        Department = department;
        Salary = salary;
    }
}

class EmployeeManagementSystem
{
    private List<Employee> employees;

    public EmployeeManagementSystem()
    {
        employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public Employee GetEmployeeById(int id)
    {
        return employees.Find(emp => emp.Id == id);
    }

    public void UpdateEmployee(Employee updatedEmployee)
    {
        Employee employee = employees.Find(emp => emp.Id == updatedEmployee.Id);
        if (employee != null)
        {
            employee.Name = updatedEmployee.Name;
            employee.Department = updatedEmployee.Department;
            employee.Salary = updatedEmployee.Salary;
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    public void DeleteEmployee(int id)
    {
        Employee employee = employees.Find(emp => emp.Id == id);
        if (employee != null)
        {
            employees.Remove(employee);
            Console.WriteLine("Employee deleted successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    public List<Employee> GetAllEmployees()
    {
        return employees;
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeManagementSystem empSystem = new EmployeeManagementSystem();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Employee Management System Menu:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Find Employee by ID");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Show All Employees");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddEmployee(empSystem);
                    break;
                case "2":
                    FindEmployeeById(empSystem);
                    break;
                case "3":
                    UpdateEmployee(empSystem);
                    break;
                case "4":
                    DeleteEmployee(empSystem);
                    break;
                case "5":
                    ShowAllEmployees(empSystem);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddEmployee(EmployeeManagementSystem empSystem)
    {
        Console.WriteLine("Enter employee details:");
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Department: ");
        string department = Console.ReadLine();
        Console.Write("Salary: ");
        double salary = double.Parse(Console.ReadLine());

        empSystem.AddEmployee(new Employee(id, name, department, salary));
        Console.WriteLine("Employee added successfully.");
    }

    static void FindEmployeeById(EmployeeManagementSystem empSystem)
    {
        Console.Write("Enter employee ID: ");
        int id = int.Parse(Console.ReadLine());
        Employee employee = empSystem.GetEmployeeById(id);
        if (employee != null)
        {
            Console.WriteLine($"Employee found: {employee.Name}, Department: {employee.Department}, Salary: {employee.Salary}");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    static void UpdateEmployee(EmployeeManagementSystem empSystem)
    {
        Console.Write("Enter employee ID to update: ");
        int id = int.Parse(Console.ReadLine());
        Employee employee = empSystem.GetEmployeeById(id);
        if (employee != null)
        {
            Console.WriteLine($"Enter new details for employee ID {id}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Department: ");
            string department = Console.ReadLine();
            Console.Write("Salary: ");
            double salary = double.Parse(Console.ReadLine());

            empSystem.UpdateEmployee(new Employee(id, name, department, salary));
            Console.WriteLine("Employee updated successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    static void DeleteEmployee(EmployeeManagementSystem empSystem)
    {
        Console.Write("Enter employee ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        empSystem.DeleteEmployee(id);
    }

    static void ShowAllEmployees(EmployeeManagementSystem empSystem)
    {
        List<Employee> allEmployees = empSystem.GetAllEmployees();
        Console.WriteLine("All Employees:");
        foreach (var emp in allEmployees)
        {
            Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
        }
    }
}

