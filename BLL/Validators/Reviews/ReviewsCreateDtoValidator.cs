using BLL.DTO.Reviews;
using FluentValidation;

namespace BLL.Validations.Reviews
{
	public class ReviewsCreateDtoValidator : AbstractValidator<ReviewCreateDto>
	{
		public ReviewsCreateDtoValidator()
		{
			RuleFor(r => r.UserId)
				.NotEmpty().WithMessage("UserId is required.");

			RuleFor(r => r.CourseId)
				.GreaterThan(0).WithMessage("CourseId must be greater than 0.");

			RuleFor(r => r.Rating)
				.InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

			RuleFor(r => r.Comment)
				.MaximumLength(500).WithMessage("Comment can't exceed 500 characters.");

		}
	}
}
