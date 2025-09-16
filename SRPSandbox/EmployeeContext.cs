namespace SRPSandbox
{
    public class EmployeeContext
    {
        public static void SaveEmployeesToFile(string filePath)
        {
            File.WriteAllLines(filePath, EmployeeManager.Employees);
            Console.WriteLine($"Employees saved to {filePath}");
        }

        public static void LoadEmployeesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                EmployeeManager.Employees = new List<string>(File.ReadAllLines(filePath));
                Console.WriteLine("Employees loaded from file.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
