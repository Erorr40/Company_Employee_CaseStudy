using System.ComponentModel.DataAnnotations;

namespace Company_Employee_CaseStudy.DTOs.EmployeeDTOs
{
    public class EmployeeUpdateDTO
    {
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
        public int ProjectId { get; set; }
    }
}
