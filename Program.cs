using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using ZooAPI.Service;
using ZooAPI.controller;

namespace ZooAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<DBConnectionService>();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            
            
            
            LoadConfiguration(builder);

            ConfigureServices(builder);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            
            
            
            ConfigureMiddleware(app);

            app.Run();
        }

        private static void LoadConfiguration(WebApplicationBuilder builder)
        {
            
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
      
            builder.Services.AddControllers();

            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", corsBuilder =>
                {
                    corsBuilder
                        .WithOrigins("http://localhost:5173") // CORS
                        .WithMethods("GET", "POST", "PUT", "DELETE")
                        .WithHeaders("accept", "content-type");
                });
            });
        }

        private static void ConfigureMiddleware(WebApplication app)
        {

            
            app.UseRouting();

           
            app.UseCors("MyCorsPolicy");

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
