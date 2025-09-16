namespace SRPSandbox
{
    public class EmployeePresenter
    {
        public static void PrintEmployees()
        {
            Console.WriteLine("Employee List:");
            foreach (var emp in EmployeeManager.Employees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
