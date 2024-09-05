using MediatR;
using PinePaste.Domain.Entities;

namespace PinePaste.Application.Pastes.Queries.GetPaste;

public class GetPasteQuery(Guid pasteId) : IRequest<Paste>
{
    public Guid PasteId { get; set; } = pasteId;
}