using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Lessons
	{
		public int Id { get; set; }
		public int course_id { get; set; }
		public string title { get; set; }
		public string content { get; set; }
		public BigInteger lesson_order { get; set; }
	}
}
