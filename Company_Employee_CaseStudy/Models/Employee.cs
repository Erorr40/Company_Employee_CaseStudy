using System.ComponentModel.DataAnnotations;

namespace Company_Employee_CaseStudy.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Range(3000, 100000)]
        public decimal Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public IEnumerable<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
