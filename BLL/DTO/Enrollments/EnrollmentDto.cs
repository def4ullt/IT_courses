using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Enrollments
{
	public class EnrollmentDto
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public string UserId { get; set; } = null!;
		public DateTime EnrolledAt { get; set; }
	}
}
