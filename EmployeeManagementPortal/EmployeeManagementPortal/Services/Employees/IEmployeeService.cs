using EmployeeManagementPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.Services.Employees
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<Employee>>> GetEmployeesAsync();
        Task<ServiceResponse<Employee>> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<ActionResult<Employee>> UpdateEmployeeAsync(int id, Employee employee);
        Task<ServiceResponse<bool>> DeleteEmployeeAsync(int id);
    }
}
