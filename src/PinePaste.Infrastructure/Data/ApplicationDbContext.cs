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
        ConfigurePasteIdConversion(modelBuilder);
        SeedPastes(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void ConfigurePasteIdConversion(ModelBuilder modelBuilder)
    {
        var pasteIdConverter = new ValueConverter<PasteId, string>(
            v => v.Value,
            v => PasteId.Parse(v));

        modelBuilder.Entity<Paste>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Paste>()
            .Property(p => p.Id)
            .HasConversion(pasteIdConverter);
    }

    private static void SeedPastes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paste>().HasData(
            new Paste("This is the first seeded paste.", DateTime.MaxValue),
            new Paste("This is the second seeded paste.", DateTime.MaxValue)
        );
    }
}