namespace PinePaste.Domain.Entities;

public class Paste(string content, DateTime? expiryDate)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Content { get; private set; } = content;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? ExpiryDate { get; private set; } = expiryDate;

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Content))
            throw new InvalidOperationException("Content cannot be empty.");
    }
}
