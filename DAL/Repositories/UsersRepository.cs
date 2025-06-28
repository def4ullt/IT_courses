using System;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
	public class UsersRepository : GenericRepository<Users>, IUsersRepository
	{
		public UsersRepository(ApplicationDbContext context) : base(context) { }

		public async Task<Users?> GetByIdAsync(int id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task<Users?> GetByUsernameAsync(string username)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
		}

		public async Task AddAsync(Users users)
		{
			await _context.Users.AddAsync(users);
		}

		public void Update(Users user)
		{
			_context.Users.Update(user);
		}

		public void Delete(Users user)
		{
			_context.Users.Remove(user);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public IQueryable<Users> GetAllQueryable()
		{
			return _context.Users.AsQueryable();
		}
	}
}
