using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Users : IdentityUser
	{
		public string Role { get; set; }

		public DateTime CreatedAt { get; set; }
	
	}
}
