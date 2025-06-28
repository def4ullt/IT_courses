using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class EnrollmentsService : IEnrollmentsService
	{
		private readonly IEnrollmentsRepository _enrollmentsRepository;

		public EnrollmentsService(IEnrollmentsRepository enrollmentsRepository)
		{
			_enrollmentsRepository = enrollmentsRepository;
		}

		public async Task<Enrollments?> GetByIdAsync(int id)
		{
			return await _enrollmentsRepository.GetByIdAsync(id);
		}

		public async Task<List<Enrollments>> GetByUserIdAsync(string userId)
		{
			return await _enrollmentsRepository.GetByUserIdAsync(userId);
		}

		public async Task<List<Enrollments>> GetByCourseIdAsync(int courseId)
		{
			return await _enrollmentsRepository.GetByCourseIdAsync(courseId);
		}

		public async Task AddAsync(Enrollments enrollment)
		{
			await _enrollmentsRepository.AddAsync(enrollment);
		}

		public void Update(Enrollments enrollment)
		{
			_enrollmentsRepository.Update(enrollment);
		}

		public void Delete(Enrollments enrollment)
		{
			_enrollmentsRepository.Delete(enrollment);
		}

		public async Task SaveChangesAsync()
		{
			await _enrollmentsRepository.SaveChangesAsync();
		}

		public IQueryable<Enrollments> GetAllQueryable()
		{
			return _enrollmentsRepository.GetAllQueryable();
		}
	}
}
