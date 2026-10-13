using Company_Employee_CaseStudy.DTOs.ProjectDTOs;
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
    public class ProjectController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _unitOfWork.Projects.GetAllAsync();
            var projectDTOs = projects.Select(p => new ProjectDTO
            {
                ProjectId = p.ProjectId,
                Name = p.Name,
                StartDate = p.StartDate,
                Budget = p.Budget,
                DepartmentId = p.DepartmentId,
                Description = p.Description
            });
            return Ok(projectDTOs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            var projectDTO = new ProjectDTO
            {
                ProjectId = project.ProjectId,
                Name = project.Name,
                StartDate = project.StartDate,
                Budget = project.Budget,
                DepartmentId = project.DepartmentId,
                Description = project.Description
            };
            return Ok(projectDTO);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProject(ProjectCreateDTO project)
        {
            var newProject = new Project
            {
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                Budget = project.Budget,
                DepartmentId = project.DepartmentId
            };
            await _unitOfWork.Projects.AddAsync(newProject);
            await _unitOfWork.saveasync();
            return CreatedAtAction(nameof(GetProjectById), new { id = newProject.ProjectId }, newProject);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProject(int id, ProjectUpdateDTO project)
        {
            var existingProject = await _unitOfWork.Projects.GetByIdAsync(id);
            if (existingProject == null)
            {
                return NotFound();
            }
            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.StartDate = project.StartDate;
            existingProject.Budget = project.Budget;
            existingProject.DepartmentId = project.DepartmentId;
            _unitOfWork.Projects.UpdateAsync(existingProject);
            await _unitOfWork.saveasync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            _unitOfWork.Projects.DeleteAsync(id);
            await _unitOfWork.saveasync();
            return NoContent();
        }
    }
}
