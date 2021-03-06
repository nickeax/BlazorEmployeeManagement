using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { value = e.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployee(id);

                if(result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { value = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    return BadRequest();
                }

                var empCheckEmail = await _employeeRepository.GetEmployeeByEmail(employee.Email);

                if (empCheckEmail != null)
                {
                    ModelState.AddModelError("email", "Employee email already in use.");
                    return BadRequest(ModelState);
                }

                var createdEmployee = await _employeeRepository.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Employeeid }, createdEmployee);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPut("{employeeId:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int employeeId, Employee employee)
        {
            try
            {
                if(employeeId != employee.Employeeid)
                {
                    return BadRequest("Employee ID mismatch");
                }

                var employeeToUpdate = await _employeeRepository.GetEmployee(employeeId);

                if (employeeToUpdate == null) return StatusCode(StatusCodes.Status302Found, $"Employee with ID {employeeId} not found.");

                return await _employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { value = e.Message });
            }
        }

        [HttpDelete("{employeeId:int")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int employeeId)
        {
            var employeeToDelete = await _employeeRepository.GetEmployee(employeeId);
            if (employeeToDelete == null){
                return BadRequest();
            }

            _employeeRepository.DeleteEmployee(employeeId);

            return Ok(employeeToDelete);
        }
    }
}
