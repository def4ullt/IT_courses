using DAL.Helpers;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.UOW;
using DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public static class Extensions
	{
		public static IServiceCollection AddDALServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddScoped<IUsersRepository, UsersRepository>();
			services.AddScoped<ICoursesRepository, CoursesRepository>();
			services.AddScoped<ILessonsRepository, LessonsRepository>();
			services.AddScoped<IReviewsRepository, ReviewsRepository>();
			services.AddScoped<IEnrollmentsRepository, EnrollmentsRepository>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			
			services.AddScoped<ISortHelper<Courses>, SortHelper<Courses>>();
			services.AddScoped<ISortHelper<Lessons>, SortHelper<Lessons>>();
			services.AddScoped<ISortHelper<Users>, SortHelper<Users>>();
			services.AddScoped<ISortHelper<Reviews>, SortHelper<Reviews>>();
			services.AddScoped<ISortHelper<Enrollments>, SortHelper<Enrollments>>();

			return services;
		}
	}
}
