using Microsoft.EntityFrameworkCore;
using Velatex.Domain.Models;

namespace Valetax.Infrastructure.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            Utility.GetConnectionString() ?? throw new InvalidOperationException()
            //  "Host=localhost;Port=5432;Database=valetax;Username=postgres;Password=plisleopas");
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VJournal>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Text)
                .IsRequired();
            entity.Property(p => p.EventId)
                .ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VNode>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name)
                .IsRequired();
            entity.HasOne(p => p.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(p => p.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            // entity.HasData(new VNode() { Id = 1, Name = "Root" });
        });
        
    }

    public DbSet<VNode> Nodes { get; set; }
    public DbSet<VJournal> Journals { get; set; }
}