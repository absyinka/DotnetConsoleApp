using DotnetConsoleApp.Enum;

namespace DotnetConsoleApp.Models
{
    public record EmployeeUpdateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public Gender Gender { get; set; }
    }
}