using Company_Employee_CaseStudy.Models;
using Company_Employee_CaseStudy.Repository.GenaricRepo;
using Microsoft.EntityFrameworkCore;

namespace Company_Employee_CaseStudy.Repository.CustomRepo
{
    public class EmployeeProjectRepo : GenaricRepo<EmployeeProject>, IEmployeeProjectRepo
    {
        public EmployeeProjectRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeProject>> GetEmployeeProjectByEmployeeId(int empid)
        {
            var employeeProjects = _context.EmployeeProjects.Where(ep => ep.EmployeeId == empid).ToList();
            return employeeProjects;
        }
    }
}
