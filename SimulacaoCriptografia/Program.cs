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

            // Busca a string de conexão e a chave
            var encryptString = builder.Configuration.GetConnectionString("DataBase");
            var key = "12345";

            var decryptString = EncryptionHelper.Decrypt(encryptString, key);


            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaDeTarefasBDContext>(
                    options => options.UseSqlServer(decryptString)
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
