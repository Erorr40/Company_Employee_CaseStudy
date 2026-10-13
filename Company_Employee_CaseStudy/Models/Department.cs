using System.ComponentModel.DataAnnotations;

namespace Company_Employee_CaseStudy.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
        public IEnumerable<Project> Projects { get; set; } = new List<Project>();
    }
}
