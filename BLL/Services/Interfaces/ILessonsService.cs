using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
	public interface ILessonsService
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
