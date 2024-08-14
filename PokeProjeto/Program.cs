using PokeProjeto.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Ligando ao DB
string stringDeConexao = builder.Configuration.GetConnectionString("conexaoMySQL");

builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql(stringDeConexao,
ServerVersion.AutoDetect(stringDeConexao)));
//Terminada Conexão ao DB

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
