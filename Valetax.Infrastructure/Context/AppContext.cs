using Microsoft.EntityFrameworkCore;
using Velatex.Domain.Models;

namespace Valetax.Infrastructure.Context;

public class AppContext: DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    public DbSet<VNode> Nodes { get; set; }
}