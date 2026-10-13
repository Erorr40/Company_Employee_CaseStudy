using Company_Employee_CaseStudy.DTOs.AuthDTOs;
using Company_Employee_CaseStudy.Repository.CustomRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_Employee_CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        readonly IAuthRepo repo;

        public AuthController(IAuthRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var user = await repo.LoginAsync(login);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }
            return Ok(new { Token = user });
        }
    }
}
