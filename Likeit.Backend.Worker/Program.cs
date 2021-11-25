using Likeit.Backend.CrossCutting.Configurations.Extensions;
using Likeit.Backend.Data.Contexts;
using Likeit.Backend.Data.Redis;
using Likeit.Backend.Data.Repositories;
using Likeit.Backend.Domain.Repositories;
using Likeit.Backend.Domain.Services;
using Likeit.Backend.Worker.Configurations;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Likeit.Backend.Worker;
    public class Program
    {

        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

                    services.RegisterContext(configuration);

                    services.RegisterRedis(configuration);

                    services.RegisterDependencies();

                    services.RegisterMassTransit();
                });
    }

