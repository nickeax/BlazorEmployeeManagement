using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Departments Table
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admin" });
            
            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Employeeid = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "john@pragimtech.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Employeeid = 2,
                FirstName = "Peter",
                LastName = "Griffin",
                Email = "peter@pragimtech.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 3,
                PhotoPath = "images/peter"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Employeeid = 3,
                FirstName = "Selmer",
                LastName = "Bouvieu",
                Email = "selmer@pragimtech.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Female,
                DepartmentId = 2,
                PhotoPath = "images/selmer"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Employeeid = 4,
                FirstName = "Terry",
                LastName = "Prachett",
                Email = "terry@pragimtech.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 4,
                PhotoPath = "images/terry"
            });

        }
    }
}
