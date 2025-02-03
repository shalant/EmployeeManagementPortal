using EmployeeManagementPortal.Models;

namespace EmployeeManagementPortal.Client.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<ServiceResponse<Employee>> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
