using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Likeit.Backend.CrossCutting.Configurations.Extensions;

public static class RedisExtensions
{
    public static void RegisterRedis(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
         {
             options.Configuration = configuration.GetConnectionString("Redis");
         });

    }
}
