using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Configuration
{
	internal class CoursesConfiguration : IEntityTypeConfiguration<Courses>
	{
		public void Configure(EntityTypeBuilder<Courses> builder)
		{

			builder.HasKey(c => c.id);

			builder.Property(c => c.title)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(c => c.description)
				.IsRequired()
				.HasMaxLength(1000);

			builder.Property(c => c.instructor_id)
				.IsRequired();

			builder.Property(c => c.created_at)
				.IsRequired()
				.HasDefaultValueSql("GETDATE()");
		}
	}
}
