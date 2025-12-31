using System;
using System.Collections.Generic;
using System.IO;
using MimeDb.Net.Items;
using System.Text.Json;

namespace MimeDb.Net
{
    public static class MimeDb
    {
        private const string FileName = "db.json";
        private static readonly Lazy<IReadOnlyDictionary<string, MimeTypeDbItem>> Data = new Lazy<IReadOnlyDictionary<string, MimeTypeDbItem>>(GetData);

        public static IReadOnlyDictionary<string, MimeTypeDbItem> Items => Data.Value;

        private static Dictionary<string, MimeTypeDbItem> GetData()
        {
            using (var json = File.OpenRead(FileName))
                return JsonSerializer.Deserialize<Dictionary<string, MimeTypeDbItem>>(json, MimeDbOptions.JsonDeserializerOptions);
        }
    }
}