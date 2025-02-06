using EmployeeManagementPortal.Models;

namespace EmployeeManagementPortal.Client.Services
{
    public interface IEmployeeService
    {
        event Action EmployeeChanged;
        List<Employee> Employees { get; set; }
        Task<List<Employee>> GetAllEmployees();
        Task<ServiceResponse<Employee>> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
