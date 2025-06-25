using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Data
{
	internal class ApplicationDbContext : IdentityDbContext<Users>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }

		public override DbSet<Users> Users { get; set; }
		public DbSet<Courses> Courses { get; set; }
		public DbSet<Enrollments> Enrollments { get; set; }
		public DbSet<Lessons> Lessons { get; set; }
		public DbSet<Reviews> Reviews { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

			var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
				v => v.ToUniversalTime(),
				v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

			foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				var properties = entityType.GetProperties()
					.Where(p => p.ClrType == typeof(DateTime));

				foreach (var property in properties)
				{
					property.SetValueConverter(dateTimeConverter);
				}
			}
		}
	}
}
