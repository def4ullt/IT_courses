using System;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
	internal interface IUsersRepository : IGenericRepository<Users>
	{
		Task<Users?> GetByIdAsync(int id);
		Task<Users?> GetByUsernameAsync(string username);
		Task AddAsync(Users users);
		void Update(Users users);
		void Delete(Users users);
		Task SaveChangesAsync();
	}
}
