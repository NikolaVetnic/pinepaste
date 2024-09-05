using Microsoft.EntityFrameworkCore;
using PinePaste.Domain.Entities;

namespace PinePaste.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Paste> Pastes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data with two initial pastes
        modelBuilder.Entity<Paste>().HasData(
            new Paste("This is the first seeded paste.", DateTime.MaxValue),
            new Paste("This is the second seeded paste.", DateTime.MaxValue)
        );

        base.OnModelCreating(modelBuilder);
    }
}