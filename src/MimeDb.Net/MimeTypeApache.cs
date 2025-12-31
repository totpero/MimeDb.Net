using System;
using System.Collections.Generic;
using System.IO;
using MimeDb.Net.Items;
using System.Text.Json;

namespace MimeDb.Net
{
    public static class MimeTypeApache
    {
        private const string FileName = "apache-types.json";

        private static readonly Lazy<IReadOnlyDictionary<string, MimeTypeBasicItem>> Data = new Lazy<IReadOnlyDictionary<string, MimeTypeBasicItem>>(GetData);

        public static IReadOnlyDictionary<string, MimeTypeBasicItem> Items => Data.Value;

        private static Dictionary<string, MimeTypeBasicItem> GetData()
        {
            using (var json = File.OpenRead(FileName))
                return JsonSerializer.Deserialize<Dictionary<string, MimeTypeBasicItem>>(json, MimeDbOptions.JsonDeserializerOptions);
        }
    }
}