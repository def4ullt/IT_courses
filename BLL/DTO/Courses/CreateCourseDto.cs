using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Courses
{
	internal class CreateCourseDto
	{
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string InstructorId { get; set; } = null!;
	}
}
