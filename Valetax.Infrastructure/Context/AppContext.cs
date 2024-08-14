using Microsoft.EntityFrameworkCore;
using Velatex.Domain.Models;

namespace Valetax.Infrastructure.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5433;Database=valetax;Username=postgres;Password=plisleopas");
    }

    public DbSet<VNode> Nodes { get; set; }
}