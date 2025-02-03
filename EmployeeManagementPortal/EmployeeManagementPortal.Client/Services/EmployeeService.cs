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

        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<List<Employee>>>("api/employees");

                if(result != null)
                {
                    Employees = result.Data;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<ServiceResponse<Employee>> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
        
        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
