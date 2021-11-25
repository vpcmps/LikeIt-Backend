using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Likeit.Backend.Worker.Configurations;

internal static class MassTransitExtensions
{
    internal static void RegisterMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            var entryAssembly = Assembly.GetEntryAssembly();

            x.AddConsumers(entryAssembly);
            x.SetKebabCaseEndpointNameFormatter();

            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.ConfigureEndpoints(ctx);
            });
        });

        services.AddMassTransitHostedService(true);
    }
}



