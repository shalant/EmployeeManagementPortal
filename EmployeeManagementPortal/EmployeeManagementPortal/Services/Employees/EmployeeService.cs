using EmployeeManagementPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        public Task<Employee> AddEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Employee>> GetEmployeeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Employee>>> GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
