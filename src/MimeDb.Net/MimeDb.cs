using System.Text.Json;

namespace MimeDb.Net
{
    public static class MimeDb
    {
        private static readonly JsonSerializerOptions JsonDeserializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        private static readonly Lazy<Dictionary<string, MimeTypeDbItem>> Data = new(GetData);

        public static Dictionary<string, MimeTypeDbItem> MimeTypeItems => Data.Value;

        private static Dictionary<string, MimeTypeDbItem> GetData()
        {
            using var json = File.OpenRead(@"C:\Workspaces\GitHub\MimeDb.Net\mime-db\db.json");
            return JsonSerializer.Deserialize<Dictionary<string, MimeTypeDbItem>>(json, JsonDeserializerOptions);
        }
    }


}
