using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadEmployees);
        }

        private void LoadEmployees()
        {
            System.Threading.Thread.Sleep(2300);
            Employee e1 = new Employee
            {
                Employeeid = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "David@pragimtech.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john.jpg"
            };

            Employee e2 = new Employee
            {
                Employeeid = 2,
                FirstName = "Peter",
                LastName = "Joust",
                Email = "Peter@pragimtech.com",
                DateOfBirth = new DateTime(1950, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/peter.jpg"
            };

            Employee e3 = new Employee
            {
                Employeeid = 3,
                FirstName = "Selmer",
                LastName = "Bouvieu",
                Email = "Selmer@pragimtech.com",
                DateOfBirth = new DateTime(1990, 10, 10),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "images/selmer.jpg"
            };

            Employee e4 = new Employee
            {
                Employeeid = 4,
                FirstName = "Terry",
                LastName = "Terryhead",
                Email = "Terry@pragimtech.com",
                DateOfBirth = new DateTime(1999, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/terry.jpg"
            };

            Employees = new List<Employee> { e1, e2, e3, e4 };
        }
    }
}
