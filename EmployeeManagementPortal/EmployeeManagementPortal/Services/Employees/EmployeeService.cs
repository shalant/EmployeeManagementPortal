using EmployeeManagementPortal.Data;
using EmployeeManagementPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementPortal.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Employee>>> GetEmployeesAsync()
        {
            var response = new ServiceResponse<List<Employee>>
            {
                Data = await _context.Employees.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Employee>> GetEmployeeByIdAsync(int id)
        {
            var response = new ServiceResponse<Employee>();
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this employee does not exist";
            }
            else
            {
                response.Data = employee;
            }

            return response;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, Employee employee)
        {
            var employeeToUpdate = await _context.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (employee == null)
            {
                return employee;
            }

            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.JobTitle = employee.JobTitle;
            employeeToUpdate.Department = employee.Department;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.Phone = employee.Phone;
            employeeToUpdate.Salary = employee.Salary;
            employeeToUpdate.HealthPlan = employee.HealthPlan;

            await _context.SaveChangesAsync();

            return employeeToUpdate;
        }

        public async Task<ServiceResponse<bool>> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Employee not found"
                };
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Employee deleted"
            };

        }
    }
}
