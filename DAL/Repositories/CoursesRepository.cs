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
	public class CoursesRepository : GenericRepository<Courses>, ICoursesRepository
	{
		public CoursesRepository(ApplicationDbContext context) : base(context) { }

		public async Task<Courses?> GetByIdAsync(int id)
		{
			return await _context.Courses.FindAsync(id);
		}

		public async Task AddAsync(Courses course)
		{
			await _context.Courses.AddAsync(course);
		}

		public void Update(Courses courses)
		{
			_context.Courses.Update(courses);
		}

		public void Delete(Courses courses)
		{
			_context.Courses.Remove(courses);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public IQueryable<Courses> GetByInstructorIdAsync(string instructor_id)
		{
			return _context.Courses
				.Where(c => c.instructor_id == instructor_id);
		}

		public IQueryable<Courses> GetAllQueryable()
		{
			return _context.Courses.AsQueryable();
		}
	}
}
