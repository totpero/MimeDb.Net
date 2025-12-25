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

    private static IReadOnlyDictionary<string, MimeTypeDbItem> GetData()
    {
        using var json = File.OpenRead(@"C:\Workspaces\GitHub\MimeDb.Net\mime-db\db.json");
        return JsonSerializer.Deserialize<Dictionary<string, MimeTypeDbItem>>(json, JsonDeserializerOptions);
    }
}