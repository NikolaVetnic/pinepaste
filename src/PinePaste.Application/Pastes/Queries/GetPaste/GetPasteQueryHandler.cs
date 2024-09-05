using MediatR;
using PinePaste.Core.Interfaces;
using PinePaste.Domain.Entities;

namespace PinePaste.Application.Pastes.Queries.GetPaste;

public class GetPasteQueryHandler(IPasteRepository pasteRepository) : IRequestHandler<GetPasteQuery, Paste>
{
    public async Task<Paste?> Handle(GetPasteQuery request, CancellationToken cancellationToken)
    {
        return await pasteRepository.GetByIdAsync(request.PasteId);
    }
}