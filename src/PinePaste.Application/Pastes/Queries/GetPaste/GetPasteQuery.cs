using MediatR;
using PinePaste.Domain.Entities;
using PinePaste.Domain.ValueObjects;

namespace PinePaste.Application.Pastes.Queries.GetPaste;

public class GetPasteQuery(PasteId pasteId) : IRequest<Paste>
{
    public PasteId PasteId { get; set; } = pasteId;
}