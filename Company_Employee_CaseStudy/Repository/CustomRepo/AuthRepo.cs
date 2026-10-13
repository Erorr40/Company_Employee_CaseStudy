using Company_Employee_CaseStudy.DTOs.AuthDTOs;
using Company_Employee_CaseStudy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Company_Employee_CaseStudy.Repository.CustomRepo
{
    public class AuthRepo : IAuthRepo
    {
        readonly AppDbContext _context;
        readonly IConfiguration _configuration;

        public AuthRepo(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.NameIdentifier, user.ApplicationUserId.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["JWT:DurationInMinutes"])),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Email == loginDTO.Email);
            if (user == null)
            {
                return null;
            }
            if (user.Password == loginDTO.Password)
            {
                return GenerateToken(user);
            }
            return null;
        }
    }
}
