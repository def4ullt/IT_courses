using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users
{
	public class UserUpdateDto
	{
		public string UserName { get; set; } = null!;
		public string Id { get; set; } = null!;
		public string? Email { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public DateTime? BirthDate { get; set; }
	}
}
