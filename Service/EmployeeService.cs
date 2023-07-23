using System.ComponentModel.Design;
using DotnetConsoleApp.Enum;
using DotnetConsoleApp.Models;
using DotnetConsoleApp.Repository;
using DotnetConsoleApp.Shared;

namespace DotnetConsoleApp.Service
{
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> employees = new List<Employee>();
        private readonly IEmployeeRepository _repository = new EmployeeRepository();

        public void CreateEmployee(EmployeeDto request)
        {
            Console.Write("Enter firstname: ");
            request.FirstName = Console.ReadLine();

            Console.Write("Enter lastname: ");
            request.LastName = Console.ReadLine();

            Console.Write("Enter middlename: ");
            request.MiddleName = Console.ReadLine();

            int gender = Helper.SelectEnum("Enter employee gender:\nEnter 1 for Male\nEnter 2 for Female: ", 1, 2);
            request.Gender = (Gender)gender;

            Console.Write("Enter date of birth (2003-01-01): ");
            var dob = DateOnly.TryParse(Console.ReadLine(), out DateOnly newDob); 
            request.DateOfBirth = newDob;

            Console.Write("Enter date joined (2003-01-01): ");
            var joinedDate = DateTime.TryParse(Console.ReadLine(), out DateTime newJoinedDate);
            request.DateJoined = newJoinedDate;

            var employee = _repository.Create(request);

            employees.Add(employee);
        }

        public void GetAllEmployees()
        {
            throw new NotImplementedException();
        }
    }
}