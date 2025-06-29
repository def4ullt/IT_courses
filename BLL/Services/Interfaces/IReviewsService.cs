using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Services.Interfaces
{
	public interface IReviewsService
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
