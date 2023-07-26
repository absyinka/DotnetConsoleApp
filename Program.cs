using System.ComponentModel.Design;
using DotnetConsoleApp.Menu;
using DotnetConsoleApp.Repository;
using DotnetConsoleApp.Service;
using DotnetConsoleApp.Shared;
// Be able to Create an employee record
// Be able to update an employee record
// Be able to find employee by employee code
// Be able to find employee by Id or employee code
// Be able to remove/delete employee record
// Be able to list all employee records (Fetch all)


// DTO - Data Tranfer Object

// A class can inherit (or extend) another class, 
// A class can also implement more than one interface



// int[] number = { 0, 1, 5, 7, 10 };

// var lastIndex = number.Length - 1;

// var lastValue = number[number.Length - 1];

// Console.WriteLine($"Last Index: {lastIndex}");
// Console.WriteLine($"Last Value: {lastValue}");

Console.WriteLine("=========Employee Data Management Application (EDMA)==========");
var repository = new EmployeeRepository();
var employeeService = new EmployeeService(repository);
Menu.MainMenu(employeeService);