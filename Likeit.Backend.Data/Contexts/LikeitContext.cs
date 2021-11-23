using Likeit.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Likeit.Backend.Data.Contexts;

public class LikeitContext : DbContext
{
    public LikeitContext(DbContextOptions<LikeitContext> opcoes) : base(opcoes)
    { }

    public DbSet<Article> Articles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("PGDatabase");
        optionsBuilder.UseNpgsql(connectionString);
    }
}