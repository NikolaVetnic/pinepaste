using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PinePaste.Domain.Entities;
using PinePaste.Domain.ValueObjects;

namespace PinePaste.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Paste> Pastes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure PasteId to be treated as a string in the database
        var pasteIdConverter = new ValueConverter<PasteId, string>(
            v => v.Value,            // Convert PasteId to string when saving
            v => PasteId.Parse(v));    // Convert string back to PasteId when querying

        modelBuilder.Entity<Paste>()
            .HasKey(p => p.Id);   // Set PasteId as the primary key

        modelBuilder.Entity<Paste>()
            .Property(p => p.Id)
            .HasConversion(pasteIdConverter);

        // Seed data with two initial pastes
        modelBuilder.Entity<Paste>().HasData(
            new Paste("This is the first seeded paste.", DateTime.MaxValue),
            new Paste("This is the second seeded paste.", DateTime.MaxValue)
        );

        base.OnModelCreating(modelBuilder);
    }
}