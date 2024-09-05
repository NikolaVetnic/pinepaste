using PinePaste.Domain.Entities;
using PinePaste.Domain.ValueObjects;

namespace PinePaste.Core.Interfaces;

public interface IPasteRepository
{
    Task<IEnumerable<Paste>> GetAllAsync();
    Task<Paste?> GetByIdAsync(PasteId id);
    Task AddAsync(Paste paste);
}