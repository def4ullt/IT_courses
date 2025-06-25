using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	internal class Courses
	{
		public int Id { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public string instructor_id { get; set; }
		public DateTime created_at { get; set; }
	}
}
