using MediatR;
using PinePaste.Core.Interfaces;
using PinePaste.Domain.Entities;
using PinePaste.Domain.ValueObjects;

namespace PinePaste.Application.Pastes.Commands.CreatePaste;

public class CreatePasteCommandHandler(IPasteRepository pasteRepository) : IRequestHandler<CreatePasteCommand, PasteId>
{
    public async Task<PasteId> Handle(CreatePasteCommand request, CancellationToken cancellationToken)
    {
        var paste = new Paste(request.Content, request.ExpiryDate);
        paste.Validate();

        await pasteRepository.AddAsync(paste);

        return paste.Id;
    }
}