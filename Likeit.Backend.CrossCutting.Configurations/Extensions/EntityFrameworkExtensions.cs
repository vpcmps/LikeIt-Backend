using Likeit.Backend.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Likeit.Backend.CrossCutting.Configurations.Extensions;

public static class EntityFrameworkExtensions
{
    public static void RegisterContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LikeitContext>(x => x.UseNpgsql(configuration.GetConnectionString("PGDatabase")));
    }
}