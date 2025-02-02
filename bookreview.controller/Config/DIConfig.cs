using bookreview.common;
using bookreview.infrastructure.Repository;
using bookreview.infrastructure.Repository.EFCore;
using bookreview.service.Services;
using bookreview.service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bookreview.controller.Config
{
    public static partial class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddDbContextPool<DatabaseContext>(
                options => options.UseSqlServer(AppSettingsProvider.SqlServerConnectionString, options =>
                {
                    options.EnableRetryOnFailure();
                }));


            ////services.AddDbContext<DatabaseContext>(
            ////    dbContextOptions => dbContextOptions
            ////    .UseMySql(AppSettingsProvider.MySqlConnectionString, ServerVersion.AutoDetect(AppSettingsProvider.MySqlConnectionString))
            ////    // The following three options help with debugging, but should
            ////    // be changed or removed for production.
            ////    .LogTo(Console.WriteLine, LogLevel.Information)
            ////    .EnableSensitiveDataLogging()
            ////    .EnableDetailedErrors()
            ////);

            services.AddScoped<DatabaseContext>();

            services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<IDapperRepository, DapperRepository>();

            return services;
        }
    }
}
