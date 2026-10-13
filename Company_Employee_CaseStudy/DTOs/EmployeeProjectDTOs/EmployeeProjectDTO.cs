using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Employee_CaseStudy.DTOs.EmployeeProjectDTOs
{
    public class EmployeeProjectDTO
    {
        public int EmployeeProjectId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        [Required, MaxLength(50)]
        public string AssignedRole { get; set; }
        [Required]
        public DateTime AssigmentDate { get; set; }
    }
}
