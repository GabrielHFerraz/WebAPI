using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interfaces;
using WebAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite("Data Source=app.db"));


builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped<IProduto, RepositoryProduto>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();