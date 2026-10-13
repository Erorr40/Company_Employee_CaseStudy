using Company_Employee_CaseStudy.DTOs.DepartmentDTOs;
using Company_Employee_CaseStudy.Models;
using Company_Employee_CaseStudy.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_Employee_CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        readonly IUnitOfWork _UoW;

        public DepartmentController(IUnitOfWork uoW)
        {
            _UoW = uoW;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _UoW.Departments.GetAllAsync();
            var departmentDtos = departments.Select(d => new DepartmentDTO
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name,
                Location = d.Location
            });
            return Ok(departmentDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _UoW.Departments.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            var departmentDto = new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name,
                Location = department.Location
            };
            return Ok(departmentDto);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> CreateDepartment(DepartmentCreateDTO departmentdto)
        {
            if (departmentdto == null)
            {
                return BadRequest();
            }
            var department = new Department
            {
                Name = departmentdto.Name,
                Location = departmentdto.Location
            };
            await _UoW.Departments.AddAsync(department);
            await _UoW.saveasync();
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.DepartmentId }, department);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateDepartment(int id, DepartmentUpdateDTO department)
        {
            var existingDepartment = await _UoW.Departments.GetByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }
            var departmentToUpdate = new Department
            {
                DepartmentId = id,
                Name = department.Name,
                Location = department.Location
            };
            await _UoW.Departments.UpdateAsync(departmentToUpdate);
            await _UoW.saveasync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var existingDepartment = await _UoW.Departments.GetByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }
            await _UoW.Departments.DeleteAsync(id);
            await _UoW.saveasync();
            return NoContent();
        }
    }
}
