using Company_Employee_CaseStudy.Models;
using Company_Employee_CaseStudy.Repository.GenaricRepo;

namespace Company_Employee_CaseStudy.Repository.CustomRepo
{
    public interface IEmployeeProjectRepo : IGenaricRepo<EmployeeProject>
    {
        public Task<IEnumerable<EmployeeProject>> GetEmployeeProjectByEmployeeId(int empid);
    }
}
