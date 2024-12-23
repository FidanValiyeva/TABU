
using Babu.DAL;
using Babu.Services.Abstarcts;
using Babu.Services.Implements;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace Babu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();




            builder.Services.AddDbContext<BabuDbContext>(x => x.UseSqlServer
            (builder.Configuration.GetConnectionString("MSSql")));

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            
            builder.Services.AddScoped<ILanguageService, LanguageService>();


              
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
    }
}
