using System;
using System.Collections.Generic;
using System.IO;
using MimeDb.Net.Items;
using System.Text.Json;

namespace MimeDb.Net
{
    public static class MimeTypeIana
    {
        private const string FileName = "iana-types.json";

        private static readonly Lazy<IReadOnlyDictionary<string, MimeTypeItem>> Data = new Lazy<IReadOnlyDictionary<string, MimeTypeItem>>(GetData);

        public static IReadOnlyDictionary<string, MimeTypeItem> Items => Data.Value;

        private static Dictionary<string, MimeTypeItem> GetData()
        {
            using (var json = File.OpenRead(FileName))
                return JsonSerializer.Deserialize<Dictionary<string, MimeTypeItem>>(json, MimeDbOptions.JsonDeserializerOptions);
        }
    }
}