using Microsoft.EntityFrameworkCore;
using PinePaste.Core.Interfaces;
using PinePaste.Domain.Entities;
using PinePaste.Infrastructure.Data;

namespace PinePaste.Infrastructure.Repositories;

public class PasteRepository(ApplicationDbContext context) : IPasteRepository
{
    public async Task<IEnumerable<Paste>> GetAllAsync()
    {
        return await context.Pastes.ToListAsync();  // Implementation for retrieving all pastes
    }

    public async Task<Paste?> GetByIdAsync(Guid id)
    {
        return await context.Pastes.FindAsync(id);
    }

    public async Task AddAsync(Paste paste)
    {
        await context.Pastes.AddAsync(paste);
        await context.SaveChangesAsync();
    }
}
