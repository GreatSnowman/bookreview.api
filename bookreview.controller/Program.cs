
using atomic.chicken.common;
using atomic.chicken.controller.Config;
using atomic.chicken.infrastructure.Repository.EFCore;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

namespace atomic.chicken.controller
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = BuildServices(args);

            var app = builder.Build();

            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static WebApplicationBuilder BuildServices(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            AppSettingsProvider.SqlServerConnectionString = builder.Configuration.GetConnectionString("SqlServer") ?? throw new NullReferenceException();
            AppSettingsProvider.MySqlConnectionString = builder.Configuration.GetConnectionString("MySql") ?? throw new NullReferenceException();

            builder.Services.RegisterApplicationServices();
            // Add services to the container.

            builder.Services.AddControllers()
                .AddDataAnnotationsLocalization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.PropertyNameCaseInsensitive = true;
            });

            builder.Services.Configure<ConnectionStringSettings>(options =>
            {
                options.ConnectionString = builder.Configuration.GetConnectionString("SqlServer") ?? throw new NullReferenceException();
            });

            return builder;
        }
    }
}