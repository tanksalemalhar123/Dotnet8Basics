using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PlugAndPlay.Api.Managers;
using PlugAndPlay.Api.Providers;
using PlugAndPlay.Api.Data;
using PlugAndPlay.Api.Middleware;
using PlugAndPlay.Api.Common.Discounts;



namespace PlugAndPlay.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Also try to load a solution-level appsettings.json (one directory up) so
            // the DefaultConnection from the repository root is available when running
            // from the src/PlugAndPlay.Api folder during development.
            builder.Configuration.AddJsonFile("../appsettings.json", optional: true, reloadOnChange: true);

            // Register services
            builder.Services.AddSingleton<IAgendaProvider, InMemoryAgendaProvider>();

            // Configure EF Core DbContext (scoped) using Postgres connection string
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            // Use HelloProvider as the implementation for IHelloProvider (scoped because it depends on DbContext)
            builder.Services.AddScoped<IHelloProvider, HelloProvider>();

            // Register managers (scoped)
            builder.Services.AddScoped<AgendaManager>();
            builder.Services.AddScoped<HelloManager>();

            builder.Services.AddScoped<IEmployeeProvider, EmployeeProvider>();
            builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();

            builder.Services.AddScoped<IDiscountStrategy, FestivalDiscountStrategy>();
            builder.Services.AddScoped<IDiscountStrategy, EmployeeDiscountStrategy>();
            builder.Services.AddScoped<OrderManager>();



            builder.Services.AddControllers();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlugAndPlay API", Version = "v1" });
            });

            var app = builder.Build();


            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware<LoggerMiddleware>();

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
