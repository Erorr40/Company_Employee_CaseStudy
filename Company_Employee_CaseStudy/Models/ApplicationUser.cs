using System.ComponentModel.DataAnnotations;

namespace Company_Employee_CaseStudy.Models
{
    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }
        [Required, MaxLength(150), MinLength(20)]
        public string Name { get; set; }
        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
        [Required, MaxLength(30)]
        public string Role { get; set; }
    }
}
