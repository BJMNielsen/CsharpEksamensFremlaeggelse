namespace CsharpEksamensFremlæggelse.Part5LINQ;

public class MainPart5
{
    public static void Run()
    {
        Console.WriteLine(
            "---------------------LINQ - LANGUAGE INTEGRATED QUERY-----------------------------------------------------------\n");
        // A library used to execute queries directly in C# syntax against many types of data
        
        // Først laver vi en liste af employees
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Department = "IT", Salary = 60000m },
            new Employee { Id = 2, Name = "Carl Smith", Department = "Sales", Salary = 55000m },
            new Employee { Id = 3, Name = "Bob Johnson", Department = "Acquisitions", Salary = 50000m },
            new Employee { Id = 4, Name = "Susan Williams", Department = "IT", Salary = 65000m },
            new Employee { Id = 5, Name = "Michael Brown", Department = "Sales", Salary = 45000m },
        };

        Console.WriteLine("List of employees before using LINQ:");
        // Printing out the employees before sorting them
        PrintEmployees(employees);

        // -----------------------------------------------------------------------------
        
        // EXTENSION method til at finde dem der arbejder i Sales Department
        var salesDepartmentEmployeesExtension = employees
            .Where(e => e.Department == "Sales")
            .ToList();
        // Minder mere om almindelig C#

        Console.WriteLine("Sales department (Extension Method):");
        PrintEmployees(salesDepartmentEmployeesExtension);
        
        // -----------------------------------------------------------------------------
        
        // QUERY selection
        var salesDepartmentEmployeesQuery =
            from e in employees
            where e.Department == "Sales"
            select e;
        
        
        // Under the hood, it gets translated into extension method calls.

        Console.WriteLine("Sales department (Query Selection):");
        PrintEmployees(salesDepartmentEmployeesQuery);

        // -----------------------------------------------------------------------------

        // Using Extension Method Syntax for complex multi-criteria sorting
        var complexSortedExtension = employees
            .Where(employee => employee.Id % 2 != 0) // kun ulige ID
            .OrderBy(employee => employee.Department) // Primary Sort by Department
            .ThenByDescending(employee => employee.Salary) // Secondary Sort by Salary (Descending)
            .ThenBy(employee => employee.Name) // Tertiary Sort by Name if same salary level
            .ToList();

        Console.WriteLine("Complex Sorted List using Extension Method Syntax:");
        PrintEmployees(complexSortedExtension);

        // -----------------------------------------------------------------------------
        
        // Using Query Selection Syntax for complex multi-criteria sorting
        var complexSortedQuery =
            from employee in employees
            where employee.Id % 2 != 0
            orderby 
                employee.Department, 
                employee.Salary descending, 
                employee.Name
            select employee;

        Console.WriteLine("Complex Sorted List using Query Selection Syntax:");
        PrintEmployees(complexSortedQuery);
        // -----------------------------------------------------------------------------


        var distinctEmps = employees.DistinctBy(employee => employee.Department);
        Console.WriteLine("DISTINCT:");
        PrintEmployees(distinctEmps);

        var takeTwoEmps = employees.Take(2);
        Console.WriteLine("TAKE 2 first Employees:");
        PrintEmployees(takeTwoEmps);

        var skipTwoEmps = employees.Skip(2);
        Console.WriteLine("SKIP 2 first Employees:");
        PrintEmployees(skipTwoEmps);

        var groupByDepartmentEmps = employees.GroupBy(employee => employee.Department).ToList();
        Console.WriteLine("GROUPBY Department:");
        PrintEmployees(groupByDepartmentEmps);
        
        var selectedEmpsNames = employees.Where(employee => employee.Name.Length <= 12).Select(employee => employee.Name);
        Console.WriteLine("WHERE name is 12 or less SELECT name:");
        Console.Write("Name:\t");
        selectedEmpsNames.ToList().ForEach(name => Console.Write($"{name}\t"));
        
        Console.WriteLine();
        Console.WriteLine("REVERSE selected names:");
        var reverseSelectedEmpsNames = selectedEmpsNames.Reverse().ToList();
        Console.Write("Name:\t");
        reverseSelectedEmpsNames.ToList().ForEach(name => Console.Write($"{name}\t"));
        Console.WriteLine("\n---------------------------------------------------\n");

        // First, Sum, Min, Max
        Employee firstEmp = employees.First();
        decimal salarySum = employees.Sum(employee => employee.Salary);
        decimal salaryMin = employees.Min(employee => employee.Salary);
        decimal salaryMax = employees.Max(employee => employee.Salary);
        Console.WriteLine($"First Employee: {firstEmp.Name} - SalarySum: {salarySum} - salaryMin: {salaryMin} - salaryMax: {salaryMax}");
        

    }

    private static void PrintEmployees(List<IGrouping<string, Employee>> groupByDepartmentEmps)
    {
        foreach (var empGroup in groupByDepartmentEmps)
        {
            Console.WriteLine($"Department {empGroup.Key}:");
            Console.Write("\t");
            foreach (var employee in empGroup)
            {
                Console.Write($"{employee.Name}\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("----------------------------------------------------------------\n");
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Department: {Department}, Salary: {Salary:C}";
        }
        
    }

    public static void PrintEmployees(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.ToString());
        }
        Console.WriteLine("----------------------------------------------------------------\n");
    }
    
    // Method er overloadet for at undgå at skulle skrive gentagende kode, når Query selection skal laves om til en liste, via .ToList()
    public static void PrintEmployees(IEnumerable<Employee> employees)
    {
        PrintEmployees(employees.ToList());
    }
}