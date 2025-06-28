using DAL.Entities;

namespace BLL.Services.Interfaces
{
	internal interface IEnrollmentsService
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
