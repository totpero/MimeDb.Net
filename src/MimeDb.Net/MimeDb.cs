using System.Text.Json;

namespace MimeDb.Net;

public static class MimeDb
{
    private static readonly JsonSerializerOptions JsonDeserializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        //Converters = { new JsonStringEnumConverter() }
    };

    private static readonly Lazy<IReadOnlyDictionary<string, MimeTypeDbItem>> Data = new(GetData);

    public static IReadOnlyDictionary<string, MimeTypeDbItem> Items => Data.Value;

    private static Dictionary<string, MimeTypeDbItem> GetData()
    {
        using var json = File.OpenRead("db.json");
        return JsonSerializer.Deserialize<Dictionary<string, MimeTypeDbItem>>(json, JsonDeserializerOptions);
    }
}