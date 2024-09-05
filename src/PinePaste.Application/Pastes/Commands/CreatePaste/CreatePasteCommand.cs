using MediatR;

namespace PinePaste.Application.Pastes.Commands.CreatePaste;

public class CreatePasteCommand : IRequest<Guid>
{
    public required string Content { get; set; }
    public DateTime? ExpiryDate { get; set; }
}
