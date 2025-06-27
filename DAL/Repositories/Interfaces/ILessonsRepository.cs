using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
	public interface ILessonsRepository : IGenericRepository<Lessons>
	{
		Task<Lessons?> GetByIdAsync(int id);
		Task<List<Lessons>> GetByCourseIdAsync(int courseId);
		Task AddAsync(Lessons lesson);
		void Update(Lessons lesson);
		void Delete(Lessons lesson);
		Task SaveChangesAsync();
		IQueryable<Lessons> GetAllQueryable();
	}
}
