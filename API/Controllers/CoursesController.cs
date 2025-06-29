using BLL.DTO.Courses;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CoursesController : ControllerBase
	{
		private readonly ICourseService _courseService;

		public CoursesController(ICourseService courseService)
		{
			_courseService = courseService;
		}

		// GET: api/courses
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CourseResponseDto>>> GetAll()
		{
			var courses = await _courseService.GetAllCoursesAsync();
			return Ok(courses);
		}

		// GET: api/courses/{id}
		[Authorize(Roles = "Admin,Instructor")]
		[HttpGet("{id}")]
		public async Task<ActionResult<CourseResponseDto>> GetById(int id)
		{
			var course = await _courseService.GetByIdAsync(id);
			return Ok(course);
		}

		// GET: api/courses/instructor/{instructorId}
		[HttpGet("instructor/{instructorId}")]
		public async Task<ActionResult<IEnumerable<CourseResponseDto>>> GetByInstructor(string instructorId)
		{
			var courses = await _courseService.GetIntructorByIdAsync(instructorId);
			return Ok(courses);
		}

		// POST: api/courses
		[HttpPost]
		[Authorize(Roles = "Admin,Instructor")]
		public async Task<ActionResult<CourseResponseDto>> Create([FromBody] CourseResponseDto dto)
		{
			var response = await _courseService.CreateCourseAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
		}

		// PUT: api/courses/{id}
		[HttpPut("{id}")]
		[Authorize(Roles = "Admin,Instructor")]
		public async Task<IActionResult> Update(int id, [FromBody] CourseResponseDto dto)
		{
			await _courseService.UpdateCourseAsync(id, dto);
			return NoContent();
		}

		// DELETE: api/courses/{id}
		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			await _courseService.DeleteAnswerAsync(id);
			return NoContent();
		}

		// GET: api/courses/paginated?pageNumber=1&pageSize=10
		[HttpGet("paginated")]
		public async Task<ActionResult<PagedList<Courses>>> GetPaginated([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
		{
			var pagedList = new PagedList<Courses>(new List<Courses>(), 0, pageNumber, pageSize);
			var paginated = await _courseService.GetPaginatedAsync(pagedList, HttpContext.RequestAborted);
			return Ok(paginated);
		}
	}
}
