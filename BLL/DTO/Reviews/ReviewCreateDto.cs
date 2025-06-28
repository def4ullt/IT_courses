using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Reviews
{
	public class ReviewCreateDto
	{
		public int CourseId { get; set; }
		public string UserId { get; set; } = null!;
		public string Comment { get; set; } = null!;
		public int Rating { get; set; }
	}
}
