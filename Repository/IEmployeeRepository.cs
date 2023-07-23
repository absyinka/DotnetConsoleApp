using DotnetConsoleApp.Models;

namespace DotnetConsoleApp.Repository
{
    public interface IEmployeeRepository
    {
        Employee Create(EmployeeDto request);
        List<Employee> GetAllEmployees();
    }
}