using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
	[NotMapped]
	public class UsersConfiguration : IEntityTypeConfiguration<Users>
	{
		public void Configure(EntityTypeBuilder<Users> builder)
		{

			builder.HasKey(u => u.Id);

			builder.Property(u => u.UserName)
				.IsRequired()
				.HasMaxLength(256);

			builder.Property(u => u.Email)
				.IsRequired()
				.HasMaxLength(256);

			builder.Property(u => u.Role)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(u => u.CreatedAt)
				.IsRequired()
				.HasDefaultValueSql("CURRENT_TIMESTAMP");
		}
	}
}
