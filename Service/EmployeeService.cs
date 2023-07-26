using DotnetConsoleApp.Enum;
using DotnetConsoleApp.Models;
using DotnetConsoleApp.Repository;
using DotnetConsoleApp.Shared;

namespace DotnetConsoleApp.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _repository; // DI stands for Dependency Injection

        public EmployeeService(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public void CreateEmployee(EmployeeDto request)
        {
            try
            {
                Console.Write("Enter firstname: ");
                request.FirstName = Console.ReadLine()!;

                Console.Write("Enter lastname: ");
                request.LastName = Console.ReadLine()!;

                Console.Write("Enter middlename: ");
                request.MiddleName = Console.ReadLine();

                int gender = Helper.SelectEnum("Enter employee gender:\nEnter 1 for Male\nEnter 2 for Female: ", 1, 2);
                request.Gender = (Gender)gender;

                Console.Write("Enter date of birth (2003-01-01): ");
                var dob = Helper.TryParseDateOnly(Console.ReadLine()!);
                request.DateOfBirth = dob;

                Console.Write("Enter date joined (2003-01-01): ");
                var joinedDate = Helper.TryParseDateOnly(Console.ReadLine()!);
                request.DateJoined = joinedDate;

                var employee = _repository.Create(request);

                _repository.employees.Add(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllEmployees()
        {
            try
            {
                if (_repository.employees.Count != 0)
                {
                    foreach (var employee in _repository.employees)
                    {
                        Console.WriteLine($"Id: {employee.Id}\tEmployee code: {employee.EmployeeCode}\tFirstName: {employee.FirstName}\tLastname: {employee.LastName}\tDateJoined: {employee.DateJoined}");
                    }

                    return;
                }

                Console.WriteLine("No records found!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}