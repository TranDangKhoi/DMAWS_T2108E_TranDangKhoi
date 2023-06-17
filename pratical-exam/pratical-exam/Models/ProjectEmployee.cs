using System.ComponentModel.DataAnnotations;

namespace pratical_exam.Models
{
	public class ProjectEmployee
	{
		[Key]
		public int ProjectEmployeeId { get; set; }
		public int EmployeeId { get; set; }
		public int ProjectId { get; set; }
		[Required]
		public string Tasks { get; set; }
		public virtual Employee Employees { get; set; }
		public virtual Project Projects { get; set; }
	}
}
