using FluentValidation;
using FluentValidation.AspNetCore;
using Likeit.Backend.Application.Services;
using Likeit.Backend.Data.Contexts;
using Likeit.Backend.Data.Redis;
using Likeit.Backend.Data.Repositories;
using Likeit.Backend.Domain.Entities;
using Likeit.Backend.Domain.Repositories;
using Likeit.Backend.Domain.Services;
using Likeit.Backend.Domain.Validators;
using MassTransit;
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

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq();
});

builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IRedisRepository, RedisRepository>();
builder.Services.AddScoped<IArticleAppService, ArticleAppService>();
builder.Services.AddScoped<IArticleDomainService, ArticleDomainService>();

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