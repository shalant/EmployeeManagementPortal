﻿namespace EmployeeManagementPortal.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? JobTitle { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Salary { get; set; }
        public HealthPlan? HealthPlan { get; set; }

    }
}
