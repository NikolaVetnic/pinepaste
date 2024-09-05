using PinePaste.Domain.ValueObjects;

namespace PinePaste.Domain.Entities;

public class Paste(string content, DateTime? expiryDate)
{
    public PasteId Id { get; private set; } = PasteId.New();
    public string Content { get; private set; } = content;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? ExpiryDate { get; private set; } = expiryDate;

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Content))
            throw new InvalidOperationException("Content cannot be empty.");
    }
}
