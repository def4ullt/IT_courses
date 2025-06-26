using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	internal class EnrollmentsRepository : GenericRepository<Enrollments>, IEnrollmentsRepository
	{
		public EnrollmentsRepository(ApplicationDbContext context) : base(context) { }

		public async Task<Enrollments?> GetByIdAsync(int id)
		{
			return await _context.Enrollments.FindAsync(id);
		}

		public async Task<List<Enrollments>> GetByUserIdAsync(string userId)
		{
			return await _context.Enrollments
				.Where(e => e.user_id == userId)
				.ToListAsync();
		}

		public async Task<List<Enrollments>> GetByCourseIdAsync(int courseId)
		{
			return await _context.Enrollments
				.Where(e => courseId == e.course_id)
				.ToListAsync();
		}

		public async Task AddAsync(Enrollments enrollments)
		{
			await _context.Enrollments.AddAsync(enrollments);
		}

		public void Update(Enrollments enrollments)
		{
			_context.Enrollments.Update(enrollments);
		}

		public void Delete(Enrollments enrollments)
		{
			_context.Enrollments.Remove(enrollments);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public async IQueryable<Enrollments> GetAllQueryable()
		{
			return _context.Enrollments.
		}
	}
}
