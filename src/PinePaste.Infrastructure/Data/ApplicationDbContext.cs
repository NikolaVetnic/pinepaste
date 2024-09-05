using Microsoft.EntityFrameworkCore;
using PinePaste.Domain.Entities;

namespace PinePaste.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Paste> Pastes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}