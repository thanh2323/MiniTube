using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniYoutube.Infrastructure.Data;

namespace MiniYoutube.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<SqlDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(SqlDbContext).Assembly.FullName);
                });

                // Enable sensitive data logging in development
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            });

            return services;
        }
    }
}
