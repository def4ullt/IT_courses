using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Courses;
using DAL.Entities;
using DAL.Helpers;

namespace BLL.Services.Interfaces
{
	public interface ICourseService
	{
		Task<CourseResponseDto> GetByIdAsync(int id);
		Task<IEnumerable<CourseResponseDto>> GetIntructorByIdAsync(string instructorId);
		Task<CourseResponseDto> CreateCourseAsync(CourseResponseDto courseRequestDto);
		Task UpdateCourseAsync(int id, CourseResponseDto courseRequestDto);
		Task DeleteAnswerAsync(int id);
		Task<IEnumerable<CourseResponseDto>> GetAllCoursesAsync();

		Task<PagedList<Courses>> GetPaginatedAsync(PagedList<Courses> pagedList, CancellationToken cancellationToken);
	}
}
