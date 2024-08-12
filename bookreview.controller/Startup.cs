////using atomic.chicken.common;
////using atomic.chicken.controller.Config;
////using Microsoft.AspNetCore.Builder;
////using Microsoft.AspNetCore.Http.Json;
////using Microsoft.AspNetCore.Localization;

////public class Startup
////{
////    public Startup(IConfiguration configuration)
////    {
////        Configuration = configuration;

////        BuildAppSettingsProvider();
////    }
////    private IConfiguration Configuration { get; }

////    // This method gets called by the runtime. Use this method to add services to the container.
////    public void ConfigureServices(IServiceCollection services)
////    {
////        services.RegisterApplicationServices();
////        // Add services to the container.

////        services.AddControllers()
////            .AddDataAnnotationsLocalization();
////        services.AddEndpointsApiExplorer();
////        services.AddSwaggerGen();
////        services.Configure<JsonOptions>(options =>
////        {
////            options.SerializerOptions.PropertyNameCaseInsensitive = true;
////        });

////        services.Configure<ConnectionStringSettings>(options =>
////        {
////            options.ConnectionString = Configuration.GetConnectionString("SqlServer") ?? throw new NullReferenceException();
////        });

////        AppSettingsProvider.ConnectionString = Configuration.GetConnectionString("SqlServer") ?? throw new NullReferenceException();

////    }

////    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
////    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
////    {
////        if (app == null)
////        {
////            throw new ArgumentNullException(nameof(app));
////        }
////        if (!env.IsProduction())
////        {
////            app.UseSwagger();
////            app.UseSwaggerUI();
////        }
////        else
////        {
////            app.UseHsts();
////        }

////        app.UseRouting();
////        app.UseHttpsRedirection();
////        app.UseAuthorization();
////    }

////    private void BuildAppSettingsProvider()
////    {
////    }
////}