using DAL.Data;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
	internal class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly ApplicationDbContext _context;
		protected readonly DbSet<T> _dbSet;

		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return await _dbSet.ToListAsync(cancellationToken);
		}

		public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
		}

		public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
		{
			return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
		}

		public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
		{
			await _dbSet.AddAsync(entity, cancellationToken);
			return entity;
		}

		public Task Update(T entity, CancellationToken cancellationToken = default)
		{
			_dbSet.Update(entity);
			return Task.CompletedTask;
		}

		public async Task Delete(T entity, CancellationToken cancellationToken = default)
		{
			_dbSet.Remove(entity);
			await Task.CompletedTask;
		}
	}
}
