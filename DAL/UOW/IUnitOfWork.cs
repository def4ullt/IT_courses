using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;

namespace DAL.UOW
{
	public interface IUnitOfWork : IDisposable
	{
		IEnrollmentsRepository Enrollments { get; }
		IUsersRepository Users { get; }
		IReviewsRepository Reviews { get; }
		ILessonsRepository Lessons { get; }
		ICoursesRepository Courses { get; }
	
		Task<int> SaveChangesAsync();
	}
}
