using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Lessons
{
	internal class LessonUpdateDto
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public string Title { get; set; } = null!;
		public string Content { get; set; } = null!;
		public int Order { get; set; }
	}
}
