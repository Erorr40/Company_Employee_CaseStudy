using Company_Employee_CaseStudy.Models;
using Company_Employee_CaseStudy.Repository.GenaricRepo;

namespace Company_Employee_CaseStudy.Repository.CustomRepo
{
    public interface IEmployeeRepo : IGenaricRepo<Employee>
    {
        public Task<IEnumerable<Employee>> GetEmployeeByName(string name);
        public Task<IEnumerable<Employee>> GetEmployeeByDepartmentId(int depid);
    }
}
