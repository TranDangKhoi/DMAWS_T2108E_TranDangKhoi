using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pratical_exam.Data;
using pratical_exam.Models;

namespace pratical_exam.Controllers
{
	[Route("api/project")]
	[ApiController]
	public class ProjectController : ControllerBase
	{

		private readonly ApplicationDbContext _context;

		public ProjectController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProjects()
		{
			List<Project> projects = await _context.Projects.ToListAsync();
			return Ok(projects);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProjectById(int id)
		{
			Project project = await _context.Projects.FindAsync(id);

			if (project == null)
			{
				return NotFound();
			}

			return Ok(project);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProject(Project project)
		{
			if (ModelState.IsValid)
			{
				_context.Projects.Add(project);
				await _context.SaveChangesAsync();
				return CreatedAtAction(nameof(GetProjectById), new { id = project.ProjectId }, project);
			}

			return BadRequest(ModelState);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProject(int id, Project project)
		{
			if (id != project.ProjectId)
			{
				return BadRequest();
			}

			if (ModelState.IsValid)
			{
				_context.Entry(project).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return NoContent();
			}

			return BadRequest(ModelState);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProject(int id)
		{
			Project project = await _context.Projects.FindAsync(id);

			if (project == null)
			{
				return NotFound();
			}

			_context.Projects.Remove(project);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
