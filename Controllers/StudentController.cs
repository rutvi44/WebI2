using Microsoft.AspNetCore.Mvc;

using StudentsApp.Entities;
using StudentsApp.Models;
using StudentsApp.Services;

namespace StudentsApp.Controllers
{
	public class StudentController : Controller
	{
		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet("/students/{status?}")]
		public IActionResult Items(string status)
		{
			List<Student> students;
			if (status == null || status == "All" || status == "")
			{
				students = _studentService.GetAllStudents();
				status = "All";
			}
			else
			{
				students = _studentService.GetStudentsByStatus(status);
			}

			var studentsViewModel = new StudentViewModel()
			{
				Students = students,
				NewStudent = new Student(),
				EnrollmentStatuses = _studentService.GetAllStatuses(),
				ActiveEnrollmentStatus = status
            };

			return View("Items", studentsViewModel);
		}


        private IStudentService _studentService;
	}
}
