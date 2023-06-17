using Microsoft.EntityFrameworkCore;
using pratical_exam.Models;

namespace pratical_exam.Data
{
	public class ApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Project> Projects { get; set; }
	}
}
