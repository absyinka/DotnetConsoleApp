using DotnetConsoleApp.Enum;

namespace DotnetConsoleApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}