using MediatR;
using PinePaste.Core.Interfaces;
using PinePaste.Domain.Entities;

namespace PinePaste.Application.Pastes.Commands.CreatePaste;

public class CreatePasteCommandHandler(IPasteRepository pasteRepository) : IRequestHandler<CreatePasteCommand, Guid>
{
    public async Task<Guid> Handle(CreatePasteCommand request, CancellationToken cancellationToken)
    {
        var paste = new Paste(request.Content, request.ExpiryDate);
        paste.Validate();

        await pasteRepository.AddAsync(paste);

        return paste.Id;
    }
}