using StudentsApp.Entities;

namespace StudentsApp.Models
{
	public class StudentViewModel
	{
		public List<Student> Students { get; set; }
		public Student NewStudent { get; set; }
		public ICollection<string> EnrollmentStatuses { get; set; }
		public string ActiveEnrollmentStatus { get; set; }
	}
}
