using System.ComponentModel.DataAnnotations;

namespace pratical_exam.Models
{
	public class Project
	{
		[Key]
		public int ProjectId { get; set; }
		[Required]
		public string ProjectName { get; set; }
		[Required]
		public DateTime ProjectStartDate { get; set; }
		[Required]
		public DateTime? ProjectEndDate { get; set; }

		public virtual ICollection<ProjectEmployee> ProjectEmployees {get; set;}
	}
}
