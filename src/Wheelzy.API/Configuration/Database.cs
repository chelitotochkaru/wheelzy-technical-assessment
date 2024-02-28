using System;
using Microsoft.EntityFrameworkCore;
using Wheelzy.Infrastructure;

namespace Wheelzy.API.Configuration
{
	public static class Database
	{
		public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ApplicationDatabaseContext>(options => options.UseSqlServer(connectionString));

			return services;
		}

        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app, IServiceProvider serviceProvider, IHostEnvironment environment)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDatabaseContext>();

                if (!environment.IsProduction())
                {
                    context.Database.Migrate();
                }
            }

            return app;
        }
    }
}

