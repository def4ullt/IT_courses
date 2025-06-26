using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	internal class ReviewsRepository : GenericRepository<Reviews>, IReviewsRepository
	{
		public ReviewsRepository(ApplicationDbContext context) : base(context) { }

		public async Task<Reviews?> GetByIdAsync(int id)
		{
			return await _context.Reviews.FindAsync(id);
		}

		public async Task<List<Reviews>> GetByUserIdAsync(string userId)
		{
			return await _context.Reviews
				.Where(r => r.user_id == userId)
				.ToListAsync();
		}

		public async Task<List<Reviews>> GetByCourseIdAsync(int courseId)
		{
			return await _context.Reviews
				.Where(r => r.course_id == courseId)
				.ToListAsync();
		}

		public async Task AddAsync(Reviews review)
		{
			await _context.Reviews.AddAsync(review);
		}

		public void Update(Reviews review)
		{
			_context.Reviews.Update(review);
		}

		public void Delete(Reviews review)
		{
			_context.Reviews.Remove(review);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public IQueryable<Reviews> GetAllQueryable()
		{
			return _context.Reviews;
		}
	}
}
