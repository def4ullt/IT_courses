using BLL.DTO.Courses;
using BLL.DTO.Enrollments;
using BLL.DTO.Lessons;
using BLL.DTO.Reviews;
using BLL.DTO.Users;
using BLL.Services;
using BLL.Services.Interfaces;
using BLL.Validations.Courses;
using BLL.Validations.Lessons;
using BLL.Validations.Reviews;
using BLL.Validators.Enrollment;
using BLL.Validators.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using KnowledgeCheck.BLL.Validators.User;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
	public static class Extensions
	{
		public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
		{
			// Services
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ICourseService, CourseService>();
			services.AddScoped<ILessonsService, LessonsService>();
			services.AddScoped<IReviewsService, ReviewsService>();
			services.AddScoped<IEnrollmentsService, EnrollmentsService>();
			services.AddScoped<IAuthService, AuthService>();

			// FluentValidation
			services.AddFluentValidationAutoValidation();

			// Users
			services.AddScoped<IValidator<UserCreateDto>, UserCreateDtoValidator>();
			services.AddScoped<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();

			// Courses
			services.AddScoped<IValidator<CreateCourseDto>, CoursesCreateDtoValidator>();
			services.AddScoped<IValidator<UpdateCourseDto>, CoursesUpdateDtoValidator>();

			// Lessons
			services.AddScoped<IValidator<LessonCreateDto>, LessonsCreateDtoValidator>();
			services.AddScoped<IValidator<LessonUpdateDto>, LessonsUpdateDtoValidator>();

			// Reviews
			services.AddScoped<IValidator<ReviewCreateDto>, ReviewsCreateDtoValidator>();
			services.AddScoped<IValidator<ReviewUpdateDto>, ReviewsUpdateDtoValidator>();

			// Enrollments
			services.AddScoped<IValidator<EnrollmentCreateDto>, EnrollmentCreateDtoValidator>();
			services.AddScoped<IValidator<EnrollmentUpdateDto>, EnrollmentUpdateDtoValidator>();

			services.AddHttpContextAccessor();

			return services;
		}
	}
}
