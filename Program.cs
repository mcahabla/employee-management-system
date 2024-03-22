
using System;
using System.Collections.Generic;

//entity 'Emmployee' with properties Id, Name, Department & Salary
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public Employee(int id, string name, string department, double salary)
    {
        //initialize variables
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
        //initialize a new list name called employees of type Employee
        employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        //method to add the employee object to the list
        employees.Add(employee);
    }

    public Employee GetEmployeeById(int id)
    {
        //finds employee based on the ID provided
        return employees.Find(emp => emp.Id == id);
    }

    public void UpdateEmployee(Employee updatedEmployee)
    {
        //find employee based on the employee ID provided
        Employee employee = employees.Find(emp => emp.Id == updatedEmployee.Id);

        //checks if the employee with the ID exists
        if (employee != null)
        {
            employee.Name = updatedEmployee.Name;
            employee.Department = updatedEmployee.Department;
            employee.Salary = updatedEmployee.Salary;
        }
        else
        {
            //if does not exist, prints this message
            Console.WriteLine("Employee not found.");
        }
    }

    public void DeleteEmployee(int id)
    {
        //find employee based on the employee ID provided
        Employee employee = employees.Find(emp => emp.Id == id);

        //checks if employee ID exist
        if (employee != null)
        {
            //if exists, removes it from the list
            employees.Remove(employee);
            Console.WriteLine("Employee deleted successfully.");
        }
        else
        {
            //if does not exists, prints this message
            Console.WriteLine("Employee not found.");
        }
    }

    public List<Employee> GetAllEmployees()
    {
        //returns the list of all employees in the list
        return employees;
    }
}

class Program
{
    static void Main(string[] args)
    {
        //initialize instance and assign it to empSystem
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

            //reads input from the user and assigns it to variable choice
            string choice = Console.ReadLine() ?? "";

            //perform operation based on the value of choice
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
        //prompts user to enter employee details needed
        Console.WriteLine("Enter employee details:");
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Department: ");
        string department = Console.ReadLine();

        Console.Write("Salary: ");
        double salary = double.Parse(Console.ReadLine());

        //create new Employee object with the details entered by the user
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
        //prompts user to enter employee ID to update details
        Console.Write("Enter employee ID to update: ");
        
        //parse user input to variable int
        int id = int.Parse(Console.ReadLine());

        //checks if employee id exists in the list
        Employee employee = empSystem.GetEmployeeById(id);
        if (employee != null)
        {
            //prompts the user to enter updated details for the employee
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
            //prints message if employee ID is not found on the list
            Console.WriteLine("Employee not found.");
        }
    }

    static void DeleteEmployee(EmployeeManagementSystem empSystem)
    {
        //prompts user to enter employee ID to delete
        Console.Write("Enter employee ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        empSystem.DeleteEmployee(id);
    }

    static void ShowAllEmployees(EmployeeManagementSystem empSystem)
    {
        //deaclares a new list that stored the object of Employee
        List<Employee> allEmployees = empSystem.GetAllEmployees();
        Console.WriteLine("All Employees:");

        //foreach loop to iterate over each object in the list
        foreach (var emp in allEmployees)
        {
            Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
        }
    }
}

