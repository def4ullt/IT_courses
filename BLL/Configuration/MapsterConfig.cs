using BLL.DTO.Courses;
using BLL.DTO.Enrollments;
using BLL.DTO.Lessons;
using BLL.DTO.Reviews;
using BLL.DTO.Users;
using DAL.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Configuration
{
	public static class MapsterConfig
	{
		public static void RegisterMappings()
		{
			TypeAdapterConfig<Users, UserResponseDto>.NewConfig()
				.Map(dest => dest.Id, src => src.Id)
				.Map(dest => dest.UserName, src => src.UserName)
				.Map(dest => dest.Email, src => src.Email)
				.Map(dest => dest.CreatedAt, src => src.CreatedAt);

			TypeAdapterConfig<UserCreateDto, Users>.NewConfig()
				.Map(dest => dest.UserName, src => src.UserName)
				.Map(dest => dest.Email, src => src.Email)
				;

			TypeAdapterConfig<UserUpdateDto, Users>.NewConfig()
				.IgnoreNullValues(true)
				.Map(dest => dest.Email, src => src.Email)
				.Map(dest => dest.UserName, src => src.UserName);

			// Courses
			TypeAdapterConfig<Courses, CourseResponseDto>.NewConfig()
				.Map(dest => dest.Id, src => src.Id)
				.Map(dest => dest.title, src => src.title)
				.Map(dest => dest.description, src => src.description)
				.Map(dest => dest.instructor_id, src => src.instructor_id)
				.Map(dest => dest.created_at, src => src.created_at);

			TypeAdapterConfig<CreateCourseDto, Courses>.NewConfig()
				.Map(dest => dest.title, src => src.Title)
				.Map(dest => dest.description, src => src.Description)
				.Map(dest => dest.instructor_id, src => src.InstructorId);

			TypeAdapterConfig<UpdateCourseDto, Courses>.NewConfig()
				.IgnoreNullValues(true)
				.Map(dest => dest.title, src => src.Title)
				.Map(dest => dest.description, src => src.Description);

			// Lessons
			TypeAdapterConfig<Lessons, LessonResponseDto>.NewConfig()
				.Map(dest => dest.Id, src => src.Id)
				.Map(dest => dest.CourseId, src => src.course_id)
				.Map(dest => dest.Title, src => src.title)
				.Map(dest => dest.Content, src => src.content)
				.Map(dest => dest.Order, src => src.lesson_order);

			TypeAdapterConfig<LessonCreateDto, Lessons>.NewConfig()
				.Map(dest => dest.course_id, src => src.CourseId)
				.Map(dest => dest.title, src => src.Title)
				.Map(dest => dest.content, src => src.Content)
				.Map(dest => dest.lesson_order, src => src.Order);

			TypeAdapterConfig<LessonUpdateDto, Lessons>.NewConfig()
				.IgnoreNullValues(true)
				.Map(dest => dest.title, src => src.Title)
				.Map(dest => dest.content, src => src.Content)
				.Map(dest => dest.lesson_order, src => src.Order);

			// Reviews
			TypeAdapterConfig<Reviews, ReviewResponseDto>.NewConfig()
				.Map(dest => dest.Id, src => src.Id)
				.Map(dest => dest.CourseId, src => src.course_id)
				.Map(dest => dest.UserId, src => src.user_id)
				.Map(dest => dest.Rating, src => src.rating)
				.Map(dest => dest.Comment, src => src.comment)
				.Map(dest => dest.CreatedAt, src => src.created_at);

			TypeAdapterConfig<ReviewCreateDto, Reviews>.NewConfig()
				.Map(dest => dest.course_id, src => src.CourseId)
				.Map(dest => dest.user_id, src => src.UserId)
				.Map(dest => dest.rating, src => src.Rating)
				.Map(dest => dest.comment, src => src.Comment);

			TypeAdapterConfig<ReviewUpdateDto, Reviews>.NewConfig()
				.IgnoreNullValues(true)
				.Map(dest => dest.rating, src => src.Rating)
				.Map(dest => dest.comment, src => src.Comment);

			// Enrollments
			TypeAdapterConfig<Enrollments, EnrollmentResponseDto>.NewConfig()
				.Map(dest => dest.Id, src => src.Id)
				.Map(dest => dest.UserId, src => src.user_id)
				.Map(dest => dest.CourseId, src => src.course_id)
				.Map(dest => dest.EnrolledAt, src => src.enrolled_at);

			TypeAdapterConfig<EnrollmentCreateDto, Enrollments>.NewConfig()
				.Map(dest => dest.user_id, src => src.user_id)
				.Map(dest => dest.course_id, src => src.course_id)
				.Map(dest => dest.enrolled_at, src => src.enrolled_at);

			TypeAdapterConfig<EnrollmentUpdateDto, Enrollments>.NewConfig()
				.IgnoreNullValues(true)
				.Map(dest => dest.enrolled_at, src => src.enrolled_at);
		}

		public static IServiceCollection AddMapsterConfiguration(this IServiceCollection services)
		{
			RegisterMappings();
			services.AddMapster();

			return services;
		}
	}
}
