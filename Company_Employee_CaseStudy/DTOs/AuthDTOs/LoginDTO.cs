using System.ComponentModel.DataAnnotations;

namespace Company_Employee_CaseStudy.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
    }
}
