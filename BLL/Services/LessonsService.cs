using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
	public class LessonsService : ILessonsService
	{
		private readonly ILessonsRepository _lessonsRepository;

		public LessonsService(ILessonsRepository lessonsRepository)
		{
			_lessonsRepository = lessonsRepository;
		}

		public async Task<Lessons?> GetByIdAsync(int id)
		{
			return await _lessonsRepository.GetByIdAsync(id);
		}

		public async Task<List<Lessons>> GetByCourseIdAsync(int courseId)
		{
			return await _lessonsRepository.GetByCourseIdAsync(courseId);
		}

		public async Task AddAsync(Lessons lesson)
		{
			await _lessonsRepository.AddAsync(lesson);
		}

		public void Update(Lessons lesson)
		{
			_lessonsRepository.Update(lesson);
		}

		public void Delete(Lessons lesson)
		{
			_lessonsRepository.Delete(lesson);
		}

		public async Task SaveChangesAsync()
		{
			await _lessonsRepository.SaveChangesAsync();
		}

		public IQueryable<Lessons> GetAllQueryable()
		{
			return _lessonsRepository.GetAllQueryable();
		}
	}
}
