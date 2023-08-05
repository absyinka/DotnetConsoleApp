using ConsoleTables;
using DotnetConsoleApp.Constants;
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

                Console.Write("Enter email address: ");
                request.Email = Console.ReadLine()!;

                int gender = Helper.SelectEnum("Enter employee gender:\nEnter 1 for Male\nEnter 2 for Female: ", 1, 2);
                request.Gender = (Gender)gender;

                Console.Write("Enter date of birth (2003-12-25): ");
                var dob = Helper.TryParseDateOnly(Console.ReadLine()!);
                request.DateOfBirth = dob;

                Console.Write("Enter date joined (2003-12-25): ");
                var joinedDate = Helper.TryParseDateOnly(Console.ReadLine()!);
                request.DateJoined = joinedDate;

                var findEmployee = _repository.FindByEmail(request.Email);

                if (findEmployee is not null)
                {
                    Console.WriteLine($"Record with {findEmployee.Email} already exist!");
                    return;
                }

                var employee = _repository.Create(request);

                _repository.employees.Add(employee);
                Console.WriteLine($"Record with `{request.Email}` created successfully");

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        public void GetAllEmployees()
        {
            try
            {
                if (_repository.employees.Count != 0)
                {
                    var table = new ConsoleTable("Id", "Employee Code", "Firstname", "Lastname", "Date Joined");

                    foreach (var employee in _repository.employees)
                    {
                        table.AddRow(employee.Id, employee.EmployeeCode, employee.FirstName, employee.LastName, employee.DateJoined);
                    }

                    table.Write(Format.Alternative);

                    return;
                }

                Console.WriteLine(Messages.NORECORDSFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteEmployee()
        {
            try
            {
                Console.Write("Enter employee code of employee to delete: ");
                string code = Console.ReadLine()!;
                var employee = _repository.FindByCode(code);

                if (employee is not null)
                {
                    _repository.employees.Remove(employee);
                    Console.WriteLine(Messages.RECORDREMOVED);
                    return;
                }

                Console.WriteLine(Messages.NOTFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateEmployee(EmployeeUpdateDto request)
        {
            try
            {
                Console.Write("Enter ID for employee to update record: ");
                int id = int.Parse(Console.ReadLine()!);
                var employee = _repository.FindById(id);

                if (employee is not null)
                {
                    Console.Write("Enter new firstname: ");
                    employee.FirstName = request.FirstName = Console.ReadLine()!;

                    Console.Write("Enter new lastname: ");
                    employee.LastName = request.LastName = Console.ReadLine()!;

                    Console.Write("Enter new middlename: ");
                    employee.MiddleName = request.MiddleName = Console.ReadLine()!;

                    int genderUpdate = Helper.SelectEnum("Enter employee gender:\nEnter 1 for Male\nEnter 2 for Female: ", 1, 2);
                    employee.Gender = request.Gender = (Gender)genderUpdate;

                    Console.WriteLine(Messages.RECORDUPDATED);
                    return;
                }

                Console.WriteLine(Messages.NOTFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ViewEmployee()
        {
            try
            {
                Console.Write("Enter employee code to search: ");
                string code = Console.ReadLine()!;

                var employee = _repository.FindByCode(code);

                if (employee is not null)
                {
                    PrintEmployeeDetail(employee);
                    return;
                }

                Console.WriteLine(Messages.NOTFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PrintEmployeeDetail(Employee employee)
        {
            Console.WriteLine(
            $@"Id: {employee.Id}
            Employee Code: {employee.EmployeeCode}
            Firstname: {employee.FirstName}
            Lastname: {employee.LastName}
            Middlename: {employee.MiddleName}
            Email: {employee.Email}
            Gender: {employee.Gender}
            Date Of Birth: {employee.DateOfBirth.ToShortDateString()}
            Date Joined {employee.DateJoined.ToString("dd/MM/yyyy")}"
            );
        }
    }
}