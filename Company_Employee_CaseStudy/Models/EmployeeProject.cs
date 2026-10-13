using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Employee_CaseStudy.Models
{
    public class EmployeeProject
    {
        public int EmployeeProjectId { get; set; }
        [Required, ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required, ForeignKey("Project")]
        public int ProjectId { get; set; }
        [Required, MaxLength(50)]
        public string AssignedRole { get; set; }
        [Required]
        public DateTime AssigmentDate { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
