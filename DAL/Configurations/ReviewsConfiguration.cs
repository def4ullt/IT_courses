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
	public class ReviewsConfiguration : IEntityTypeConfiguration<Reviews>
	{
		public void Configure(EntityTypeBuilder<Reviews> builder)
		{

			builder.HasKey(r => r.Id);

			builder.Property(r => r.user_id)
				.IsRequired();

			builder.Property(r => r.course_id)
				.IsRequired();

			builder.Property(r => r.rating)
				.IsRequired()
				.HasDefaultValue(0);

			builder.Property(r => r.comment)
				.IsRequired()
				.HasMaxLength(1000);

			builder.Property(r => r.created_at)
				.IsRequired()
				.HasDefaultValueSql("NOW()");

			builder.HasOne<Users>()
				.WithMany()
				.HasForeignKey(r => r.user_id)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne<Courses>()
				.WithMany()
				.HasForeignKey(r => r.course_id)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
