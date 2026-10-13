using System.ComponentModel.DataAnnotations;

namespace Company_Employee_CaseStudy.DTOs.DepartmentDTOs
{
    public class DepartmentUpdateDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }
    }
}
