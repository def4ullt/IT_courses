using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Configuration
{
	internal class LessonsConfiguration : IEntityTypeConfiguration<Lessons>
	{
		public void Configure(EntityTypeBuilder<Lessons> builder)
		{

			builder.HasKey(l => l.Id);

			builder.Property(l => l.Id)
				.HasColumnName("id")
				.IsRequired();

			builder.Property(l => l.course_id)
				.HasColumnName("course_id")
				.IsRequired();

			builder.Property(l => l.title)
				.HasColumnName("title")
				.IsRequired()
				.HasMaxLength(255);

			builder.Property(l => l.content)
				.HasColumnName("content")
				.IsRequired();

			builder.Property(l => l.lesson_order)
				.HasColumnName("lesson_order")
				.IsRequired();
		}
	}
}
