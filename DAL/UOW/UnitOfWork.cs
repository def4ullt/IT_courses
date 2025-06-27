using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;
using DAL.Data;
namespace DAL.UOW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		public IUsersRepository Users { get; }
		public ICoursesRepository Courses { get; }
		public ILessonsRepository Lessons { get; }
		public IReviewsRepository Reviews { get; }
		public IEnrollmentsRepository Enrollments { get; }

		public UnitOfWork(ApplicationDbContext context,
			IUsersRepository usersRepository,
			ICoursesRepository coursesRepository,
			ILessonsRepository lessonsRepository,
			IReviewsRepository reviewsRepository,
			IEnrollmentsRepository enrollmentsRepository)
		{
			_context = context;
			Users = usersRepository;
			Courses = coursesRepository;
			Lessons = lessonsRepository;
			Reviews = reviewsRepository;
			Enrollments = enrollmentsRepository;
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
