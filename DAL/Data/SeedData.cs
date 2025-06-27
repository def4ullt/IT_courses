using Bogus;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Data
{
	public class SeedData
	{
		public static async Task SeedAsync(
			ApplicationDbContext context,
			UserManager<Users> userManager,
			RoleManager<IdentityRole> roleManager)
		{
			await context.Database.MigrateAsync();

			var roles = new[] { "Admin", "User" };
			foreach (var role in roles)
			{
				if (!await roleManager.RoleExistsAsync(role))
					await roleManager.CreateAsync(new IdentityRole(role));
			}

			if (!context.Users.Any())
			{
				var usersFaker = new Faker<Users>()
					.RuleFor(u => u.UserName, f => f.Internet.UserName())
					.RuleFor(u => u.Email, f => f.Internet.Email())
					.RuleFor(u => u.CreatedAt, f => f.Date.Past(1))
					.RuleFor(u => u.EmailConfirmed, _ => true);

				var users = usersFaker.Generate(10);
				const string password = "1234567890";

				foreach (var user in users)
				{
					var result = await userManager.CreateAsync(user, password);
					if (result.Succeeded)
						await userManager.AddToRoleAsync(user, "User");
				}

				var admin = new Users
				{
					UserName = "admin",
					Email = "admin@itcourses.com",
					EmailConfirmed = true,
					CreatedAt = DateTime.UtcNow
				};

				if ((await userManager.CreateAsync(admin, password)).Succeeded)
					await userManager.AddToRoleAsync(admin, "Admin");
			}

			// 3. Курси
			if (!context.Courses.Any())
			{
				var instructors = await context.Users.ToListAsync();

				var courseFaker = new Faker<Courses>()
					.RuleFor(c => c.title, f => f.Company.CatchPhrase())
					.RuleFor(c => c.description, f => f.Lorem.Paragraph())
					.RuleFor(c => c.instructor_id, f => f.PickRandom(instructors).Id)
					.RuleFor(c => c.created_at, f => f.Date.Past(1));

				var courses = courseFaker.Generate(5);
				await context.Courses.AddRangeAsync(courses);
				await context.SaveChangesAsync();

				foreach (var course in courses)
				{
					for (int i = 0; i < 3; i++)
					{
						var lesson = new Lessons
						{
							course_id = course.Id,
							title = new Faker().Lorem.Sentence(),
							content = new Faker().Lorem.Paragraphs(2),
							lesson_order = i + 1
						};
						await context.Lessons.AddAsync(lesson);
					}
				}
				await context.SaveChangesAsync();
			}

			var allUsers = await context.Users.ToListAsync();
			var allCourses = await context.Courses.ToListAsync();

			if (!context.Enrollments.Any())
			{
				var enrollmentsFaker = new Faker<Enrollments>()
					.RuleFor(e => e.user_id, f => f.PickRandom(allUsers).Id)
					.RuleFor(e => e.course_id, f => f.PickRandom(allCourses).Id)
					.RuleFor(e => e.enrolled_at, f => f.Date.Past(1));

				var enrollments = enrollmentsFaker.Generate(10);
				await context.Enrollments.AddRangeAsync(enrollments);
				await context.SaveChangesAsync();
			}

			if (!context.Reviews.Any())
			{
				var reviewsFaker = new Faker<Reviews>()
					.RuleFor(r => r.course_id, f => f.PickRandom(allCourses).Id)
					.RuleFor(r => r.user_id, f => f.PickRandom(allUsers).Id)
					.RuleFor(r => r.rating, f => f.Random.Int(1, 5))
					.RuleFor(r => r.comment, f => f.Lorem.Sentence())
					.RuleFor(r => r.created_at, f => f.Date.Recent(30));

				var reviews = reviewsFaker.Generate(10);
				await context.Reviews.AddRangeAsync(reviews);
				await context.SaveChangesAsync();
			}
		}
	}
}
