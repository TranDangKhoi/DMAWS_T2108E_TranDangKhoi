using System.ComponentModel.DataAnnotations;

namespace pratical_exam.Models
{
	public class Employee
	{
		[Key]
		public int EmployeeId { get; set; }
		[Required]
		public string EmployeeName {get; set;}
		[Required]
		public DateTime EmployeeDOB { get; set; }
		[Required]
		public string EmployeeDepartment { get; set; }

		public virtual ICollection<ProjectEmployee> ProjectEmployees
	}
}
