using Microsoft.EntityFrameworkCore;
using pratical_exam.Models;

namespace pratical_exam.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
	}
}
