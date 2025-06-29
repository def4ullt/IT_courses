using BLL.DTO.Reviews;
using FluentValidation;

namespace BLL.Validations.Reviews
{
	public class ReviewsUpdateDtoValidator : AbstractValidator<ReviewUpdateDto>
	{
		public ReviewsUpdateDtoValidator()
		{
			RuleFor(r => r.Rating)
				.InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

			RuleFor(r => r.Comment)
				.MaximumLength(500).WithMessage("Comment can't exceed 500 characters.");

		}
	}
}
