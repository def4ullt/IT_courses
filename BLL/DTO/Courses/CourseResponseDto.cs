using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Courses
{
	public class CourseResponseDto
	{
		public int Id { get; set; }
		public string title { get; set; } = null!;
		public string description { get; set; } = null!;

		public string instructor_id { get; set; } = null!;
		public DateTime created_at { get; set; }
	}
}
