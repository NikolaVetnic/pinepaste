using MediatR;
using PinePaste.Core.Interfaces;
using PinePaste.Domain.Entities;

namespace PinePaste.Application.Pastes.Queries.ListPastes;

public class ListPastesQueryHandler(IPasteRepository pasteRepository)
    : IRequestHandler<ListPastesQuery, IEnumerable<Paste>>
{
    public async Task<IEnumerable<Paste>> Handle(ListPastesQuery request, CancellationToken cancellationToken)
    {
        return await pasteRepository.GetAllAsync();
    }
}