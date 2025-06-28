using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class ReviewsService : IReviewsService
	{
		private readonly IReviewsRepository _reviewsRepository;

		public ReviewsService(IReviewsRepository reviewsRepository)
		{
			_reviewsRepository = reviewsRepository;
		}

		public async Task<Reviews?> GetByIdAsync(int id)
		{
			return await _reviewsRepository.GetByIdAsync(id);
		}

		public async Task<IEnumerable<Reviews>> GetByCourseIdAsync(int courseId)
		{
			return await _reviewsRepository.GetByCourseIdAsync(courseId);
		}

		public async Task<IEnumerable<Reviews>> GetByUserIdAsync(string userId)
		{
			return await _reviewsRepository.GetByUserIdAsync(userId);
		}

		public async Task AddAsync(Reviews review)
		{
			await _reviewsRepository.AddAsync(review);
		}

		public void Update(Reviews review)
		{
			_reviewsRepository.Update(review);
		}

		public void Delete(Reviews review)
		{
			_reviewsRepository.Delete(review);
		}

		public async Task SaveChangesAsync()
		{
			await _reviewsRepository.SaveChangesAsync();
		}

		public IQueryable<Reviews> GetAllQueryable()
		{
			return _reviewsRepository.GetAllQueryable();
		}
	}
}
