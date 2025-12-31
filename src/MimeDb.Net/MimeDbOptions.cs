using System.Text.Json;

namespace MimeDb.Net
{
    internal static class MimeDbOptions
    {
        internal static readonly JsonSerializerOptions JsonDeserializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            //Converters = { new JsonStringEnumConverter() }
        };

    }
}