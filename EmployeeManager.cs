namespace SRPSandbox
{
    public class EmployeeManager
    {
        public static List<string> Employees = new List<string>();

        public static void AddEmployee(string name)
        {
            Employees.Add(name);
            Console.WriteLine($"Employee {name} added successfully.");
        }
    }
}
