using MimeDb.Net.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MimeDb.Net
{
    internal static class MimeTypeBase<TItem>
        where TItem : MimeTypeBasicItem
    {
        internal static Dictionary<string, TItem> GetDataFromFile(string fileName)
        {
            using (var json = File.OpenRead(fileName))
                return JsonSerializer.Deserialize<Dictionary<string, TItem>>(json, MimeDbOptions.JsonDeserializerOptions);
        }

        internal static Lazy<IReadOnlyDictionary<string, TItem>> GetLazyData(string fileName)
        {
            return new Lazy<IReadOnlyDictionary<string, TItem>>(() => GetDataFromFile(fileName));
        }

    }
}