using Company_Employee_CaseStudy.DTOs.EmployeeProjectDTOs;
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
    public class EmployeeProjectController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        public EmployeeProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateEmployeeProject(EmployeeProjectDTO employeeProjectDTO)
        {
            var employeeProject = new EmployeeProject
            {
                EmployeeId = employeeProjectDTO.EmployeeId,
                ProjectId = employeeProjectDTO.ProjectId,
                AssigmentDate = employeeProjectDTO.AssigmentDate,
                AssignedRole = employeeProjectDTO.AssignedRole
            };
            await _unitOfWork.EmployeeProjects.AddAsync(employeeProject);
            await _unitOfWork.saveasync();
            return CreatedAtAction(nameof(GetEmployeeProjectsByEmployeeId), new { empid = employeeProject.EmployeeId }, employeeProject);
        }

        [HttpGet("{empid}")]
        public async Task<IActionResult> GetEmployeeProjectsByEmployeeId(int empid)
        {
            var employeeProjects = await _unitOfWork.EmployeeProjects.GetEmployeeProjectByEmployeeId(empid);
            if (employeeProjects == null || !employeeProjects.Any())
            {
                return NotFound();
            }
            var employeeProjectDTOs = employeeProjects.Select(ep => new EmployeeProjectDTO
            {
                EmployeeId = ep.EmployeeId,
                ProjectId = ep.ProjectId,
                EmployeeProjectId = ep.EmployeeProjectId,
                AssigmentDate = ep.AssigmentDate,
                AssignedRole = ep.AssignedRole
            });
            return Ok(employeeProjectDTOs);
        }
    }
}
