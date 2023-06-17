using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pratical_exam.Data;
using pratical_exam.Models;

namespace pratical_exam.Controllers
{
	[Route("api/employee")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public EmployeeController(ApplicationDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var employees = await _context.Employees.ToListAsync();
			return Ok(employees);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			Employee employee = await _context.Employees.FindAsync(id);

			if (employee == null)
			{
				return NotFound();
			}

			return Ok(employee);
		}

		[HttpPost]
		public async Task<IActionResult> Create(Employee employee)
		{
			if (ModelState.IsValid)
			{
				_context.Employees.Add(employee);
				await _context.SaveChangesAsync();
				return CreatedAtAction(nameof(GetById), new { id = employee.EmployeeId }, employee);
			}

			return BadRequest(ModelState);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Employee employee)
		{
			if (id != employee.EmployeeId)
			{
				return BadRequest();
			}

			if (ModelState.IsValid)
			{
				_context.Entry(employee).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return NoContent();
			}

			return BadRequest(ModelState);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			Employee employee = await _context.Employees.FindAsync(id);

			if (employee == null)
			{
				return NotFound();
			}

			_context.Employees.Remove(employee);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
