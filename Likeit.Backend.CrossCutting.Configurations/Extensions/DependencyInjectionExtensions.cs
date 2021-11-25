using FluentValidation;
using Likeit.Backend.Application.Services;
using Likeit.Backend.Data.Redis;
using Likeit.Backend.Data.Repositories;
using Likeit.Backend.Domain.Entities;
using Likeit.Backend.Domain.Repositories;
using Likeit.Backend.Domain.Services;
using Likeit.Backend.Domain.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Likeit.Backend.CrossCutting.Configurations.Extensions;

public static class DependencyInjectionExtensions
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IRedisRepository, RedisRepository>();
        services.AddScoped<IArticleAppService, ArticleAppService>();
        services.AddScoped<IArticleDomainService, ArticleDomainService>();

        services.AddTransient<IValidator<Article>, ArticleValidator>();
    }
}
