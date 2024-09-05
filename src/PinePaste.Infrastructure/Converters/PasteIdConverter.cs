using PinePaste.Domain.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinePaste.Infrastructure.Converters;

public class PasteIdConverter : JsonConverter<PasteId>
{
    // Serialize PasteId as a simple string
    public override void Write(Utf8JsonWriter writer, PasteId value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }

    // Deserialize PasteId from a string
    public override PasteId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();
        return PasteId.Parse(stringValue);
    }
}
