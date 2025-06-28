using AutoMapper;
using BLL.DTO.Courses;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Helpers;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class CourseService : ICourseService
	{
		private readonly ICoursesRepository _coursesRepository;
		private readonly IMapper _mapper;

		public CourseService(ICoursesRepository coursesRepository, IMapper mapper)
		{
			_coursesRepository = coursesRepository;
			_mapper = mapper;
		}

		public async Task<CourseResponseDto> GetByIdAsync(int id)
		{
			var course = await _coursesRepository.GetByIdAsync(id)
				?? throw new NotFoundException("Course not found");
			return _mapper.Map<CourseResponseDto>(course);
		}

		public async Task<IEnumerable<CourseResponseDto>> GetIntructorByIdAsync(string instructorId)
		{
			var courses = await _coursesRepository.GetByInstructorIdAsync(instructorId).ToListAsync();
			return _mapper.Map<IEnumerable<CourseResponseDto>>(courses);
		}

		public async Task<CourseResponseDto> CreateCourseAsync(CourseResponseDto courseRequestDto)
		{
			var course = _mapper.Map<Courses>(courseRequestDto);
			await _coursesRepository.AddAsync(course);
			await _coursesRepository.SaveChangesAsync();
			return _mapper.Map<CourseResponseDto>(course);
		}

		public async Task UpdateCourseAsync(int id, CourseResponseDto courseRequestDto)
		{
			var existingCourse = await _coursesRepository.GetByIdAsync(id)
				?? throw new NotFoundException("Course not found");
			existingCourse = _mapper.Map(courseRequestDto, existingCourse);
			_coursesRepository.Update(existingCourse);
			await _coursesRepository.SaveChangesAsync();
		}

		public async Task DeleteAnswerAsync(int id)
		{
			var course = await _coursesRepository.GetByIdAsync(id)
				?? throw new NotFoundException("Course not found");
			_coursesRepository.Delete(course);
			await _coursesRepository.SaveChangesAsync();
		}

		public async Task<IEnumerable<CourseResponseDto>> GetAllCoursesAsync()
		{
			var courses = await _coursesRepository.GetAllQueryable().ToListAsync();
			return _mapper.Map<IEnumerable<CourseResponseDto>>(courses);
		}

		public async Task<PagedList<Courses>> GetPaginatedAsync(PagedList<Courses> pagedList, CancellationToken cancellationToken)
		{
			var query = _coursesRepository.GetAllQueryable();

			var totalCount = await query.CountAsync(cancellationToken);
			var items = await query
				.Skip((pagedList.CurrentPage - 1) * pagedList.PageSize)
				.Take(pagedList.PageSize)
				.ToListAsync(cancellationToken);

			return new PagedList<Courses>(items, totalCount, pagedList.CurrentPage, pagedList.PageSize);
		}
	}
}
