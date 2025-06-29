using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
	public class EnrollmentsConfiguration : IEntityTypeConfiguration<Enrollments>
	{
		public void Configure(EntityTypeBuilder<Enrollments> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.user_id).IsRequired();
			builder.Property(e => e.course_id).IsRequired();
			builder.Property(e => e.enrolled_at).IsRequired();
			
			builder.HasOne<Users>()
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
