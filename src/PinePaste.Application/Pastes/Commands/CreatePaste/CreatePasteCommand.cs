using MediatR;
using PinePaste.Domain.ValueObjects;

namespace PinePaste.Application.Pastes.Commands.CreatePaste;

public class CreatePasteCommand : IRequest<PasteId>
{
    public required string Content { get; set; }
    public DateTime? ExpiryDate { get; set; }
}
