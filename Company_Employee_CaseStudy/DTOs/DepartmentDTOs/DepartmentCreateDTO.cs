using System.ComponentModel.DataAnnotations;

namespace Company_Employee_CaseStudy.DTOs.DepartmentDTOs
{
    public class DepartmentCreateDTO
    {
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }
    }
}
