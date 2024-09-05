using PinePaste.Domain.Entities;

namespace PinePaste.Core.Interfaces;

public interface IPasteRepository
{
    Task<IEnumerable<Paste>> GetAllAsync();
    Task<Paste?> GetByIdAsync(Guid id);
    Task AddAsync(Paste paste);
}