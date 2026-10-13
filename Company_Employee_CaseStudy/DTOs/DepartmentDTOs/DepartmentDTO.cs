using System.ComponentModel.DataAnnotations;

namespace Company_Employee_CaseStudy.DTOs.DepartmentDTOs
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }
    }
}
