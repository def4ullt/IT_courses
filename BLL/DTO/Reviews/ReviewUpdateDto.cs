using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Reviews
{
	public class ReviewUpdateDto
	{
		public int Id { get; set; }
		public string Comment { get; set; } = null!;
		public int Rating { get; set; }
	}
}
