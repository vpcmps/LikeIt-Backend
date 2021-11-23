using FluentValidation;
using FluentValidation.AspNetCore;
using Likeit.Backend.API.Contexts;
using Likeit.Backend.API.Models;
using Likeit.Backend.API.Repositories;
using Likeit.Backend.API.Validations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LikeitContext>(x => 
    x.UseNpgsql(builder.Configuration.GetConnectionString("PGDatabase")));

builder.Services.AddFluentValidation();

builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddTransient<IValidator<Article>, ArticleValidator>();

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