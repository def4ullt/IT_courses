﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users
{
	public class UserUpdateDto
	{
		public string Role { get; set; } = null!;
		public string UserName { get; set; } = null!;
		public string Email { get; set; } = null!;
	}
}
