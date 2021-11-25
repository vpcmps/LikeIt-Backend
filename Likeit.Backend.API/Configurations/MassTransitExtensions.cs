using MassTransit;

namespace Likeit.Backend.API.Configurations;

public static class MassTransitExtensions
{
    public static void RegisterMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq();
        });
    }
}
