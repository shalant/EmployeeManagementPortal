using EmployeeManagementPortal.Models;
using EmployeeManagementPortal.Services.Employees;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPortal.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Employee>>>> GetAllEmployees()
        {
            var result = await _employeeService.GetEmployeesAsync();
            return Ok(result);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Employee>>> GetEmployeeById(int id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(result);
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            var createdEmployee = new Employee
            {
                Name = employee.Name,
                JobTitle = employee.JobTitle,
                Department = employee.Department,
                Email = employee.Email,
                Phone = employee.Phone,
                Salary = employee.Salary,
                HealthPlan = employee.HealthPlan
            };

            _employeeService.AddEmployeeAsync(employee);

            return Ok(createdEmployee);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoItem(int id, Employee employee)
        {
            var result = await _employeeService.UpdateEmployeeAsync(id, employee);
            return Ok(result);
        }

        //DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            return Ok(result);
        }
    }
}
