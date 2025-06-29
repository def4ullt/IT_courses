using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Enrollments
{
	public class EnrollmentUpdateDto
	{
		public int Id { get; set; }
		public int course_id { get; set; }
		public string user_id { get; set; } = null!;
		public DateTime enrolled_at { get; set; }
	}
}
