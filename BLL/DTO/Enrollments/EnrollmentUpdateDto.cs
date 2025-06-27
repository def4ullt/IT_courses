using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Enrollments
{
	internal class EnrollmentUpdateDto
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public string UserId { get; set; } = null!;
	}
}
