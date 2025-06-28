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
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;

		public string InstructorId { get; set; } = null!;
		public string InstructorName { get; set; } = null!; // Можливо, з Users.FullName

		public int EnrollmentsCount { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
