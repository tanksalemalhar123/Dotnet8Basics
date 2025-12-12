using Microsoft.OpenApi.Models;
using PlugAndPlay.Api.Managers;
using PlugAndPlay.Api.Providers;

namespace PlugAndPlay.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register services
            builder.Services.AddSingleton<IAgendaProvider, InMemoryAgendaProvider>();
            // Use HelloProvider as the implementation for IHelloProvider
            builder.Services.AddSingleton<IHelloProvider, HelloProvider>();
            // Register managers
            builder.Services.AddScoped<AgendaManager>();
            builder.Services.AddScoped<HelloManager>();

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


            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
