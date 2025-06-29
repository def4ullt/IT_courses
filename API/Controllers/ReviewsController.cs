using BLL.DTO.Reviews;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ReviewsController : ControllerBase
	{
		private readonly IReviewsService _reviewsService;

		public ReviewsController(IReviewsService reviewsService)
		{
			_reviewsService = reviewsService;
		}

		// GET: api/reviews
		[HttpGet]
		public ActionResult<IEnumerable<Reviews>> GetAll()
		{
			var reviews = _reviewsService.GetAllQueryable().ToList();
			return Ok(reviews);
		}

		// GET: api/reviews/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Reviews>> GetById(int id)
		{
			var review = await _reviewsService.GetByIdAsync(id);
			if (review == null)
				return NotFound();

			return Ok(review);
		}

		// GET: api/reviews/course/{courseId}
		[HttpGet("course/{courseId}")]
		public async Task<ActionResult<IEnumerable<Reviews>>> GetByCourseId(int courseId)
		{
			var reviews = await _reviewsService.GetByCourseIdAsync(courseId);
			return Ok(reviews);
		}

		// GET: api/reviews/user/{userId}
		[HttpGet("user/{userId}")]
		public async Task<ActionResult<IEnumerable<Reviews>>> GetByUserId(string userId)
		{
			var reviews = await _reviewsService.GetByUserIdAsync(userId);
			return Ok(reviews);
		}

		// POST: api/reviews
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create([FromBody] ReviewCreateDto dto)
		{
			var review = new Reviews
			{
				user_id = dto.UserId,
				course_id = dto.CourseId,
				comment = dto.Comment,
				rating = dto.Rating,
				created_at = DateTime.UtcNow
			};

			await _reviewsService.AddAsync(review);
			await _reviewsService.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = review.Id }, review);
		}

		// PUT: api/reviews/{id}
		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> Update(int id, [FromBody] ReviewUpdateDto dto)
		{
			var review = await _reviewsService.GetByIdAsync(id);
			if (review == null)
				return NotFound();

			review.comment = dto.Comment;
			review.rating = dto.Rating;

			_reviewsService.Update(review);
			await _reviewsService.SaveChangesAsync();

			return NoContent();
		}

		// DELETE: api/reviews/{id}
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var review = await _reviewsService.GetByIdAsync(id);
			if (review == null)
				return NotFound();

			_reviewsService.Delete(review);
			await _reviewsService.SaveChangesAsync();

			return NoContent();
		}
	}
}
