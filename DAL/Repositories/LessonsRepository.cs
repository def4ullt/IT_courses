using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	internal class LessonsRepository : GenericRepository<Lessons>, ILessonsRepository
	{
		public LessonsRepository(ApplicationDbContext context) : base(context) { }

		public async Task<Lessons?> GetByIdAsync(int id)
		{
			return await _context.Lessons.FindAsync(id);
		}
		public async Task<List<Lessons>> GetByCourseIdAsync(int courseId)
		{
			return await _context.Lessons
				.Where(l => l.course_id == courseId)
				.ToListAsync();
		}
		
		public async Task AddAsync(Lessons lesson)
		{
			await _context.Lessons.AddAsync(lesson);
		}

		public void Update(Lessons lesson)
		{
			_context.Lessons.Update(lesson);
		}

		public void Delete(Lessons lesson)
		{
			_context.Lessons.Remove(lesson);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public IQueryable<Lessons> GetAllQueryable()
		{
			return _context.Lessons;
		}
	}
}
