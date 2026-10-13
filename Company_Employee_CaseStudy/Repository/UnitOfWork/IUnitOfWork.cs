using Company_Employee_CaseStudy.Models;
using Company_Employee_CaseStudy.Repository.CustomRepo;
using Company_Employee_CaseStudy.Repository.GenaricRepo;

namespace Company_Employee_CaseStudy.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IGenaricRepo<Department> Departments { get; }
        public IGenaricRepo<Project> Projects { get; }
        public IEmployeeRepo Employees { get; }
        public IEmployeeProjectRepo EmployeeProjects { get; }
        public Task saveasync();
    }
}
