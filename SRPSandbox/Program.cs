using SRPSandbox;

namespace SRPExample
{
    public class Program
    {

        static void Main(string[] args)
        {
            EmployeeManager.AddEmployee("Alice");
            EmployeeManager.AddEmployee("Bob");

            EmployeePresenter.PrintEmployees();

            EmployeeContext.SaveEmployeesToFile("employees.txt");
            EmployeeContext.LoadEmployeesFromFile("employees.txt");

            EmployeePresenter.PrintEmployees();
        }
    }
}
