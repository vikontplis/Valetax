using Microsoft.EntityFrameworkCore;
using Velatex.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Valetax.Infrastructure.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();

        optionsBuilder.UseNpgsql(
            configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException() 
            //  "Host=localhost;Port=5432;Database=valetax;Username=postgres;Password=plisleopas");
        );
    }

    public DbSet<VNode> Nodes { get; set; }
}