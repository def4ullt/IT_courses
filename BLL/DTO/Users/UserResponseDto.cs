using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users
{
	public class UserResponseDto
	{
		public string Id { get; set; } = null!;
		public string Role { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public string UserName { get; set; } = null!;
		public string NormalizedUserName { get; set; }
		public string Email { get; set; } = null!;
		public string NormalizedEmail { get; set; }
		public string PasswordHash { get; set; } = null!;
	}
}
