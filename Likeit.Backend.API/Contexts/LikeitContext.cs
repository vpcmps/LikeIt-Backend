using Likeit.Backend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Likeit.Backend.API.Contexts;

public class LikeitContext : DbContext
{
    public LikeitContext(DbContextOptions<LikeitContext> opcoes)
: base(opcoes)
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