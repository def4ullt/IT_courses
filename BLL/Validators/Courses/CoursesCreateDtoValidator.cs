using BLL.DTO.Courses;
using FluentValidation;

namespace BLL.Validations.Courses
{
	public class CoursesCreateDtoValidator : AbstractValidator<CreateCourseDto>
	{
		public CoursesCreateDtoValidator()
		{
			RuleFor(c => c.Title)
				.NotEmpty().WithMessage("Title is required.")
				.MaximumLength(100).WithMessage("Title can't be longer than 100 characters.");

			RuleFor(c => c.Description)
				.MaximumLength(1000).WithMessage("Description can't be longer than 1000 characters.");

			RuleFor(c => c.InstructorId)
				.NotEmpty().WithMessage("InstructorId is required.");
		}
	}
}
