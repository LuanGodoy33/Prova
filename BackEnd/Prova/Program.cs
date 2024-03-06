
using Microsoft.EntityFrameworkCore;
using Prova.Data;
using Prova.Repos;
using Prova.Repos.Interfaces;

namespace Prova
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string strConnection = builder.Configuration.GetConnectionString("Database");
            builder.Services.AddDbContext<DataDbContext>(option =>
            {
                option.UseSqlServer(strConnection);
            });

            builder.Services.AddScoped<IUsuarioRepos, UsuarioRepos>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
