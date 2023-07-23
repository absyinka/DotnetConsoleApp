using System.ComponentModel.Design;
using DotnetConsoleApp.Models;
using DotnetConsoleApp.Shared;

namespace DotnetConsoleApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> employees = new List<Employee>();

        public Employee Create(EmployeeDto request)
        {
            int id = employees.Count != 0 ? employees[employees.Count - 1].Id + 1 : 1;
            string code = Helper.GenerateCode(id);

            var employee = new Employee
            {
                Id = id,
                EmployeeCode = code,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                DateJoined = request.DateJoined,
                Created = DateTime.Now
            };

            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }
    }
}