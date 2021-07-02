using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }
        public Department GetDepartment(int departmentId)
        {
            var result = _appDbContext.Departments.FirstOrDefault(dep => dep.DepartmentId == departmentId);

            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _appDbContext.Departments;
        }
    }
}
