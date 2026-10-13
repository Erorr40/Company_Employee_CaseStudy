using Company_Employee_CaseStudy.Models;
using Company_Employee_CaseStudy.Repository.GenaricRepo;

namespace Company_Employee_CaseStudy.Repository.CustomRepo
{
    public class EmployeeRepo : GenaricRepo<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentId(int depid)
        {
            return _context.Employees.Where(e => e.DepartmentId == depid).ToList();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByName(string name)
        {
            return _context.Employees.Where(e => e.FullName == name).ToList();
        }
    }
}
