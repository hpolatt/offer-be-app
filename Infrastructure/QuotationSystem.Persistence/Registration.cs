using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using QuotationSystem.Persistence.Context;
using QuotationSystem.Application.Repositories;
using QuotationSystem.Persistence.Repositories;
using QuotationSystem.Persistence.UnitOfWorks;
using QuotationSystem.Application.UnitOfWorks;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Persistence {
	public static class Registration {
		public static void AddPersistences(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
			

			services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
			services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddIdentityCore<User>(opt => {
				opt.Password.RequireDigit = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequiredLength = 6;
				opt.SignIn.RequireConfirmedEmail = false;
			})
					.AddRoles<Role>()
					.AddEntityFrameworkStores<AppDbContext>();
			
		}
	}
}



//options.UseNpgsql("User ID=postgres;Password=root123!;Host=localhost;Port=5432;Database=offerdb;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;"));