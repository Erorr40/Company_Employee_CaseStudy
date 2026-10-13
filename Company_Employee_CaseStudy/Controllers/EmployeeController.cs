using Company_Employee_CaseStudy.DTOs.EmployeeDTOs;
using Company_Employee_CaseStudy.Models;
using Company_Employee_CaseStudy.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_Employee_CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            var employeeDTOs = employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                FullName = e.FullName,
                Email = e.Email,
                HireDate = e.HireDate,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId,
                ProjectId = e.ProjectId
            });
            return Ok(employeeDTOs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDTO = new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FullName = employee.FullName,
                Email = employee.Email,
                HireDate = employee.HireDate,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId,
                ProjectId = employee.ProjectId
            };
            return Ok(employeeDTO);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeCreateDTO employee)
        {
            var emp = new Employee
            {
                DepartmentId = employee.DepartmentId,
                Email = employee.Email,
                FullName = employee.FullName,
                HireDate = employee.HireDate,
                ProjectId = employee.ProjectId,
                Salary = employee.Salary
            };
            await _unitOfWork.Employees.AddAsync(emp);
            await _unitOfWork.saveasync();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = emp.EmployeeId }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeCreateDTO employee)
        {
            var emp = await _unitOfWork.Employees.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            emp.DepartmentId = employee.DepartmentId;
            emp.Email = employee.Email;
            emp.FullName = employee.FullName;
            emp.HireDate = employee.HireDate;
            emp.ProjectId = employee.ProjectId;
            emp.Salary = employee.Salary;
            _unitOfWork.Employees.UpdateAsync(emp);
            await _unitOfWork.saveasync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await _unitOfWork.Employees.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            _unitOfWork.Employees.DeleteAsync(id);
            await _unitOfWork.saveasync();
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchByName (string name)
        {
            var employees = await _unitOfWork.Employees.GetEmployeeByName(name);
            if (employees == null)
            {
                return NotFound();
            }
            var employeeDTOs = employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                FullName = e.FullName,
                Email = e.Email,
                HireDate = e.HireDate,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId,
                ProjectId = e.ProjectId
            });
            return Ok(employeeDTOs);
        }

        [HttpGet("department/{depid}")]
        public async Task<IActionResult> GetEmployeeByDepartmentId(int depid)
        {
            var employees = await _unitOfWork.Employees.GetEmployeeByDepartmentId(depid);
            if (employees == null)
            {
                return NotFound();
            }
            var employeeDTOs = employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                FullName = e.FullName,
                Email = e.Email,
                HireDate = e.HireDate,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId,
                ProjectId = e.ProjectId
            });
            return Ok(employeeDTOs);
        }

    }
}
