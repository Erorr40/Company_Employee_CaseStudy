using Company_Employee_CaseStudy.DTOs.AuthDTOs;
using Company_Employee_CaseStudy.Models;

namespace Company_Employee_CaseStudy.Repository.CustomRepo
{
    public interface IAuthRepo
    {
        Task<string> LoginAsync(LoginDTO login);
        string GenerateToken(ApplicationUser user);
    }
}
