using HeroesDota.Data;
using HeroesDota.Repositorio;
using HeroesDota.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Qual DB context estamos utilizando 
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<HeroDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );
builder.Services.AddScoped<IHeroRepository, HeroRepository>();
builder.Services.AddScoped<IFuncaoRepository, FuncaoRepository>();


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
