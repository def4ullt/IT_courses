using BLL.DTO.Lessons;
using FluentValidation;

namespace BLL.Validations.Lessons
{
	public class LessonsCreateDtoValidator : AbstractValidator<LessonCreateDto>
	{
		public LessonsCreateDtoValidator()
		{
			RuleFor(l => l.Title)
				.NotEmpty().WithMessage("Title is required.")
				.MaximumLength(100).WithMessage("Title can't be longer than 100 characters.");

			RuleFor(l => l.Content)
				.NotEmpty().WithMessage("Content is required.");

			RuleFor(l => l.CourseId)
				.GreaterThan(0).WithMessage("CourseId must be greater than 0.");

		}
	}
}
