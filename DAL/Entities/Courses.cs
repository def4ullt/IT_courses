using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Courses
	{

		public int Id { get; set; }
		[Column("title")]
		public string title { get; set; }
		[Column("description")]
		public string description { get; set; }
		[Column("instructor_id")]
		public string instructor_id { get; set; }
		[Column("created_at")]
		public DateTime created_at { get; set; }
	}
}
