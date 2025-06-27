using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.HelpModels
{
	public class LessonsParameters : QueryStringParameters
	{
		public string? SearchTerm { get; set; }
		public int? CourseId { get; set; }
		public int? InstructorId { get; set; }
		public DateTime? CreatedAfter { get; set; }
		public DateTime? CreatedBefore { get; set; }
		public string? SortBy { get; set; }
		public bool SortDescending { get; set; } = false;
	}
}
