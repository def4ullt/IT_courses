using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
	public interface IReviewsRepository : IGenericRepository<Reviews>
	{
		Task<Reviews?> GetByIdAsync(int id);
		Task<IEnumerable<Reviews>> GetByCourseIdAsync(int courseId);
		Task<IEnumerable<Reviews>> GetByUserIdAsync(string userId);
		Task AddAsync(Reviews review);
		void Update(Reviews review);
		void Delete(Reviews review);
		Task SaveChangesAsync();
		IQueryable<Reviews> GetAllQueryable();
	}
}
