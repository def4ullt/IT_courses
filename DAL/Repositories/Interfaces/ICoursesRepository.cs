using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
	public interface ICoursesRepository : IGenericRepository<Courses>
	{
		Task<Courses?> GetByIdAsync(int id);
		Task AddAsync(Courses courses);
		void Update(Courses courses);
		void Delete(Courses courses);
		Task SaveChangesAsync();
		IQueryable<Courses> GetByInstructorIdAsync(string instructor_id);
	}
}
