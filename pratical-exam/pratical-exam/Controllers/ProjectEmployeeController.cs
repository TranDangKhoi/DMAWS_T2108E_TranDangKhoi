using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pratical_exam.Data;
using pratical_exam.Models;

namespace pratical_exam.Controllers
{
	[Route("api/project-employee")]
	[ApiController]
	public class ProjectEmployeeController : ControllerBase
	{

		private readonly ApplicationDbContext _context;

		public ProjectEmployeeController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProjectEmployees()
		{
			List<ProjectEmployee> projectEmployees = await _context.ProjectEmployees.ToListAsync();
			return Ok(projectEmployees);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProjectEmployeeById(int id)
		{
			ProjectEmployee projectEmployee = await _context.ProjectEmployees.FindAsync(id);

			if (projectEmployee == null)
			{
				return NotFound();
			}

			return Ok(projectEmployee);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProjectEmployee(ProjectEmployee projectEmployee)
		{
			if (ModelState.IsValid)
			{
				_context.ProjectEmployees.Add(projectEmployee);
				await _context.SaveChangesAsync();
				return CreatedAtAction(nameof(GetProjectEmployeeById), new { id = projectEmployee.ProjectEmployeeId }, projectEmployee);
			}

			return BadRequest(ModelState);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProjectEmployee(int id, ProjectEmployee projectEmployee)
		{
			if (id != projectEmployee.ProjectEmployeeId)
			{
				return BadRequest();
			}

			if (ModelState.IsValid)
			{
				_context.Entry(projectEmployee).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return NoContent();
			}

			return BadRequest(ModelState);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProjectEmployee(int id)
		{
			ProjectEmployee projectEmployee = await _context.ProjectEmployees.FindAsync(id);

			if (projectEmployee == null)
			{
				return NotFound();
			}

			_context.ProjectEmployees.Remove(projectEmployee);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
