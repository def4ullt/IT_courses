using BLL.DTO.Enrollments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validators.Enrollment
{
	internal class EnrollmentUpdateDtoValidator : AbstractValidator<EnrollmentUpdateDto>
	{
		public EnrollmentUpdateDtoValidator()
		{
			RuleFor(e => e.user_id)
				.NotEmpty().WithMessage("UserId is required.");

			RuleFor(e => e.course_id)
				.GreaterThan(0).WithMessage("CourseId must be a positive number.");

			RuleFor(e => e.enrolled_at)
				.LessThanOrEqualTo(DateTime.UtcNow).WithMessage("EnrolledAt cannot be in the future.");
		}
	}
}
