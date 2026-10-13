using System.ComponentModel.DataAnnotations;

namespace Company_Employee_CaseStudy.DTOs.ProjectDTOs
{
    public class ProjectCreateDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required, Range(1000, 10000000)]
        public decimal Budget { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
