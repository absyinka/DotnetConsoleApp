using DotnetConsoleApp.Models;

namespace DotnetConsoleApp.Service
{
    public interface IEmployeeService
    {
        void CreateEmployee(EmployeeDto request);
        void GetAllEmployees();
    }
}