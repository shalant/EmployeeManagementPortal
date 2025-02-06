using EmployeeManagementPortal.Models;
using System.Net.Http.Json;

namespace EmployeeManagementPortal.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;

        public EmployeeService(HttpClient http)
        {
            _http = http;
        }

        public List<Employee> Employees { get; set; } = new List<Employee>();
        public string Message { get; set; } = "Loading employees...";

        public event Action EmployeeChanged;

        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<List<Employee>>>("api/Employee");

                if(result != null)
                {
                    Employees = result.Data;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
             if(Employees.Count == 0)
            {
                Message = "No employees found";
            }

             return Employees;
        }

        public async Task<ServiceResponse<Employee>> GetEmployeeById(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Employee>>($"api/employee/{id}");
            return result;
        }
        
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var newEmployee = new Employee()
            {
                Name = employee.Name,
                JobTitle = employee.JobTitle,
                Department = employee.Department,
                Email = employee.Email,
                Phone = employee.Phone,
                Salary = employee.Salary,
                HealthPlan = employee.HealthPlan,
            };

            var result = await _http.PostAsJsonAsync<Employee>("api/employee", newEmployee);
            return newEmployee;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var request = new Employee()
            {
                Name = employee.Name,
                JobTitle = employee.JobTitle,
                Department = employee.Department,
                Email = employee.Email,
                Phone = employee.Phone,
                Salary = employee.Salary,
                HealthPlan = employee.HealthPlan,
            };

            await _http.PutAsJsonAsync($"api/employee/{request.Id}", request);
        }

        public async Task DeleteEmployee(int id)
        {
            await _http.DeleteAsync($"api/employee/{id}");
        }
    }
}
