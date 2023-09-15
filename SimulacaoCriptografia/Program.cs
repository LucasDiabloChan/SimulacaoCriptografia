using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using SimulacaoCriptografia.Criptography;
using SimulacaoCriptografia.Data;
using SimulacaoCriptografia.Respositorios;
using SimulacaoCriptografia.Respositorios.Interfaces;

namespace SimulacaoCriptografia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at ...
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var keys[] = builder.Configuration.GetConnectionString("DataBase");
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaDeTarefasBDContext>(
                    options => options.UseSqlServer(
                        EncryptionHelper.Decrypt(key[1], key[0])
                    )
                );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline
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
