using BLL.DTO.Lessons;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class LessonsController : ControllerBase
	{
		private readonly ILessonsService _lessonsService;

		public LessonsController(ILessonsService lessonsService)
		{
			_lessonsService = lessonsService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Lessons>> GetAll()
		{
			var lessons = _lessonsService.GetAllQueryable().ToList();
			return Ok(lessons);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Lessons>> GetById(int id)
		{
			var lesson = await _lessonsService.GetByIdAsync(id);
			if (lesson == null)
				return NotFound();

			return Ok(lesson);
		}

		[HttpGet("course/{courseId}")]
		public async Task<ActionResult<IEnumerable<Lessons>>> GetByCourseId(int courseId)
		{
			var lessons = await _lessonsService.GetByCourseIdAsync(courseId);
			return Ok(lessons);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create([FromBody] LessonCreateDto dto)
		{
			var lesson = new Lessons
			{
				course_id = dto.CourseId,
				title = dto.Title,
				content = dto.Content,
				lesson_order = dto.Order
			};

			await _lessonsService.AddAsync(lesson);
			await _lessonsService.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = lesson.Id }, lesson);
		}

		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> Update(int id, [FromBody] LessonUpdateDto dto)
		{
			var lesson = await _lessonsService.GetByIdAsync(id);
			if (lesson == null)
				return NotFound();

			lesson.title = dto.Title;
			lesson.content = dto.Content;
			lesson.lesson_order = dto.Order;

			_lessonsService.Update(lesson);
			await _lessonsService.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var lesson = await _lessonsService.GetByIdAsync(id);
			if (lesson == null)
				return NotFound();

			_lessonsService.Delete(lesson);
			await _lessonsService.SaveChangesAsync();

			return NoContent();
		}
	}
}
