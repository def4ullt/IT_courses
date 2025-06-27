using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Enrollments
	{
		public int Id { get; set; }
		public string user_id { get; set; }
		public int course_id { get; set; }
		public DateTime enrolled_at { get; set; }
	}
}
