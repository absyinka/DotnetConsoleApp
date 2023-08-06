using System;
using DotnetConsoleApp.Enum;

namespace DotnetConsoleApp.Models
{
    public record EmployeeDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateOnly DateJoined { get; set; }
    }
}