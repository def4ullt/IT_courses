using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Enrollments
{
	internal class EnrollmentResponseDto
	{
		public int Id { get; set; }

		public int CourseId { get; set; }
		public string CourseTitle { get; set; } = null!; // З Courses.Title

		public string UserId { get; set; }
		public string UserName { get; set; } = null!;     // З Users.FullName або Email

		public DateTime EnrolledAt { get; set; }
	}
}
