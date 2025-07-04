﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users
{
	public class UserCreateDto
	{
		public string UserName { get; set; } = null!;
		public string NormalizedUserName { get; set; }
		public string Email { get; set; } = null!;
		public string NormalizedEmail { get; set; }
		public string Password { get; set; } = null!;
		public string Role { get; set; } = null!; 
	}
}
