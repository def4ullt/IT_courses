using BLL.DTO.Enrollments;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EnrollmentsController : ControllerBase
	{
		private readonly IEnrollmentsService _enrollmentsService;

		public EnrollmentsController(IEnrollmentsService enrollmentsService)
		{
			_enrollmentsService = enrollmentsService;
		}

		// GET: api/enrollments
		[HttpGet]
		public ActionResult<IEnumerable<Enrollments>> GetAll()
		{
			var enrollments = _enrollmentsService.GetAllQueryable().ToList();
			return Ok(enrollments);
		}

		// GET: api/enrollments/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Enrollments>> GetById(int id)
		{
			var enrollment = await _enrollmentsService.GetByIdAsync(id);
			if (enrollment == null)
				return NotFound();

			return Ok(enrollment);
		}

		// GET: api/enrollments/user/{userId}
		[HttpGet("user/{userId}")]
		public async Task<ActionResult<IEnumerable<Enrollments>>> GetByUser(string userId)
		{
			var enrollments = await _enrollmentsService.GetByUserIdAsync(userId);
			return Ok(enrollments);
		}

		// GET: api/enrollments/course/{courseId}
		[HttpGet("course/{courseId}")]
		public async Task<ActionResult<IEnumerable<Enrollments>>> GetByCourse(int courseId)
		{
			var enrollments = await _enrollmentsService.GetByCourseIdAsync(courseId);
			return Ok(enrollments);
		}

		// POST: api/enrollments
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create([FromBody] EnrollmentCreateDto dto)
		{
			var enrollment = new Enrollments
			{
				user_id = dto.user_id,
				course_id = dto.course_id,
				CreatedAt = DateTime.UtcNow
			};

			await _enrollmentsService.AddAsync(enrollment);
			await _enrollmentsService.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = enrollment.Id }, enrollment);
		}

		// PUT: api/enrollments/{id}
		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> Update(int id, [FromBody] EnrollmentUpdateDto dto)
		{
			var enrollment = await _enrollmentsService.GetByIdAsync(id);
			if (enrollment == null)
				return NotFound();

			enrollment.user_id = dto.user_id;
			enrollment.course_id = dto.course_id;

			_enrollmentsService.Update(enrollment);
			await _enrollmentsService.SaveChangesAsync();

			return NoContent();
		}

		// DELETE: api/enrollments/{id}
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var enrollment = await _enrollmentsService.GetByIdAsync(id);
			if (enrollment == null)
				return NotFound();

			_enrollmentsService.Delete(enrollment);
			await _enrollmentsService.SaveChangesAsync();

			return NoContent();
		}
	}
}
