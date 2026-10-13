using Company_Employee_CaseStudy.Models;
using Company_Employee_CaseStudy.Repository.CustomRepo;
using Company_Employee_CaseStudy.Repository.GenaricRepo;

namespace Company_Employee_CaseStudy.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, IGenaricRepo<Department> departments, IGenaricRepo<Project> projects, IEmployeeRepo employees, IEmployeeProjectRepo employeeProjects)
        {
            _context = context;
            Departments = departments;
            Projects = projects;
            Employees = employees;
            EmployeeProjects = employeeProjects;
        }

        public IGenaricRepo<Department> Departments { get; }
        public IGenaricRepo<Project> Projects { get; }
        public IEmployeeRepo Employees { get; }
        public IEmployeeProjectRepo EmployeeProjects { get; set; }

        public async Task saveasync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
