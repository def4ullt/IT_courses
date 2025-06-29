using Bogus;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Data
{
    public static class SeedData
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Застосовуємо міграції, якщо є
            await context.Database.MigrateAsync();

            // 1. Створення ролей
            string[] roles = new[] { "Admin", "Instructor", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // 2. Створення користувачів
            if (!userManager.Users.Any())
            {
                // Адміністратор
                var admin = new Users
                {
                    UserName = "admin",
                    Email = "admin@itcourses.com",
                    Role = "Admin",
                    CreatedAt = DateTime.UtcNow
                };
                await userManager.CreateAsync(admin, "Admin123!");

                // Інструктори (3 штуки)
                for (int i = 1; i <= 3; i++)
                {
                    var instructor = new Users
                    {
                        UserName = $"instructor{i}",
                        Email = $"instructor{i}@itcourses.com",
                        Role = "Instructor",
                        CreatedAt = DateTime.UtcNow
                    };
                    await userManager.CreateAsync(instructor, $"Instructor{i}!");
                }

                // Звичайні користувачі (10 штук) за допомогою Faker
                var userFaker = new Faker<Users>()
                    .RuleFor(u => u.UserName, f => f.Internet.UserName())
                    .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.UserName))
                    .RuleFor(u => u.Role, _ => "User")
                    .RuleFor(u => u.CreatedAt, f => f.Date.Past(1));

                var users = userFaker.Generate(10);

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "User123!");
                }
            }

            // 3. Курси
            if (!await context.Courses.AnyAsync())
            {
                var instructors = await context.Users.Where(u => u.Role == "Instructor").ToListAsync();

                var courseFaker = new Faker<Courses>()
                    .RuleFor(c => c.title, f => f.Commerce.ProductName())
                    .RuleFor(c => c.description, f => f.Lorem.Paragraphs(2))
                    .RuleFor(c => c.instructor_id, f => f.PickRandom(instructors).Id)
                    .RuleFor(c => c.created_at, f => f.Date.Past(1));

                var courses = courseFaker.Generate(5);
                await context.Courses.AddRangeAsync(courses);
                await context.SaveChangesAsync();

                // Уроки по 3 на кожен курс
                foreach (var course in courses)
                {
                    var lessonFaker = new Faker<Lessons>()
                        .RuleFor(l => l.course_id, _ => course.Id)
                        .RuleFor(l => l.title, f => $"Урок {f.IndexFaker + 1}: {f.Lorem.Sentence()}")
                        .RuleFor(l => l.content, f => string.Join("\n\n", f.Lorem.Paragraphs(3)))
                        .RuleFor(l => l.lesson_order, f => f.IndexFaker + 1);

                    var lessons = lessonFaker.Generate(3);
                    await context.Lessons.AddRangeAsync(lessons);
                }
                await context.SaveChangesAsync();
            }

            // 4. Записи на курси (Enrollments)
            if (!await context.Enrollments.AnyAsync())
            {
                var students = await context.Users.Where(u => u.Role == "User").ToListAsync();
                var courses = await context.Courses.ToListAsync();

                var enrollmentFaker = new Faker<Enrollments>()
                    .RuleFor(e => e.user_id, f => f.PickRandom(students).Id)
                    .RuleFor(e => e.course_id, f => f.PickRandom(courses).Id)
                    .RuleFor(e => e.enrolled_at, f => f.Date.Past(1));

                var enrollments = enrollmentFaker.Generate(20);

                await context.Enrollments.AddRangeAsync(enrollments);
                await context.SaveChangesAsync();
            }

            // 5. Відгуки (Reviews)
            if (!await context.Reviews.AnyAsync())
            {
                var courses = await context.Courses.ToListAsync();
                var users = await context.Users.ToListAsync();

                var reviewFaker = new Faker<Reviews>()
                    .RuleFor(r => r.course_id, f => f.PickRandom(courses).Id)
                    .RuleFor(r => r.user_id, f => f.PickRandom(users).Id)
                    .RuleFor(r => r.rating, f => f.Random.Int(1, 5))
                    .RuleFor(r => r.comment, f => f.Lorem.Paragraph())
                    .RuleFor(r => r.created_at, f => f.Date.Recent(30));

                var reviews = reviewFaker.Generate(15);

                await context.Reviews.AddRangeAsync(reviews);
                await context.SaveChangesAsync();
            }
        }
    }
}
