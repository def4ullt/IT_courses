using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	internal class Reviews
	{
		public int Id { get; set; }
		public int course_id { get; set; }
		public string user_id { get; set; }
		public int rating { get; set; } 
		public string comment { get; set; } 
		public DateTime created_at { get; set; } 
	}
}
