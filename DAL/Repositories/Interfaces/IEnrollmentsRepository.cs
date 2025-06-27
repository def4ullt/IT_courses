using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
	public interface IEnrollmentsRepository : IGenericRepository<Enrollments>
	{
		Task<Enrollments?> GetByIdAsync(int id);
		Task<List<Enrollments>> GetByUserIdAsync(string userId);
		Task<List<Enrollments>> GetByCourseIdAsync(int courseId);
		Task AddAsync(Enrollments enrollment);
		void Update(Enrollments enrollment);
		void Delete(Enrollments enrollment);
		Task SaveChangesAsync();
		IQueryable<Enrollments> GetAllQueryable();
	}
}
