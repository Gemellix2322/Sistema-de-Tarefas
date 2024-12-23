
using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Data;
using SistemadeTarefas.Repositorios;
using SistemadeTarefas.Repositorios.Interfaces;

namespace SistemadeTarefas
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

            builder.Services.AddDbContext<SistemaTarefasDBContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DataBase"),
                    new MySqlServerVersion(new Version(10, 4, 32))
                )
            );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

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
