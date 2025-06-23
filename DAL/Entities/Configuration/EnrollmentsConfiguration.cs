using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Configuration
{
	internal class EnrollmentsConfiguration : IEntityTypeConfiguration<Enrollments>
	{
		public void Configure(EntityTypeBuilder<Enrollments> builder)
		{
			builder.HasKey(e => e.id);
			builder.Property(e => e.user_id).IsRequired();
			builder.Property(e => e.course_id).IsRequired();
			builder.Property(e => e.enrolled_at).IsRequired();
			
			builder.HasOne<UsersConfiguration>()
				.WithMany()
				.HasForeignKey(e => e.user_id)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne<Courses>()
				.WithMany()
				.HasForeignKey(e => e.course_id)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
