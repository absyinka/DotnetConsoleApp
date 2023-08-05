using DotnetConsoleApp.Models;

namespace DotnetConsoleApp.Repository
{
    public interface IEmployeeRepository
    {
        Employee Create(EmployeeDto request);
        List<Employee> GetAllEmployees();
        Employee FindById(int id);
        Employee FindByCode(string code);
        Employee FindByEmail(string email);
    }
}