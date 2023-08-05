using DotnetConsoleApp.Service;
using DotnetConsoleApp.Models;

namespace DotnetConsoleApp.Menu
{
    public class Menu
    {
        public static void MainMenu(IEmployeeService employeeService)
        {
            bool flag = true;
            var employeeDto = new EmployeeDto();
            var updateEmployeeDto = new EmployeeUpdateDto();

            try
            {
                while (flag)
                {
                    PrintMenu();
                    Console.Write("\nPlease enter your preferred option: ");
                    string option = Console.ReadLine()!;

                    switch (option.ToLower())
                    {
                        case "1":
                            employeeService.CreateEmployee(employeeDto);
                            Console.WriteLine("");
                            break;
                        case "2":
                            employeeService.GetAllEmployees();
                            Console.WriteLine("");
                            break;
                        case "3":
                            employeeService.ViewEmployee();
                            Console.WriteLine("");
                            break;
                        case "4":
                            employeeService.UpdateEmployee(updateEmployeeDto);
                            Console.WriteLine("");
                            break;
                        case "5":
                            employeeService.DeleteEmployee();
                            Console.WriteLine("");
                            break;
                        case "0":
                            flag = false;
                            break;
                        default:
                            throw new InvalidOperationException("Unknown operation!");
                    }
                }
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Enter 1 to Add new Employee");
            Console.WriteLine("Enter 2 to View all Employees");
            Console.WriteLine("Enter 3 to View an Employee");
            Console.WriteLine("Enter 4 to Update an Employee");
            Console.WriteLine("Enter 5 to Delete an Employee");
            Console.WriteLine("Enter 0 to exit application");
        }
    }
}