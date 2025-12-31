using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static bool TryGetFileMimeType(string filename, out KeyValuePair<string, MimeTypeDbItem> item)
        {
            var ext = Path.GetExtension(filename);
            if (!string.IsNullOrEmpty(ext))
            {
                ext =  ext.Substring(1);
                var mime = Items.FirstOrDefault(
                    mt => mt.Value.Extensions != null 
                          && mt.Value.Extensions.Any(e => e.Equals(ext, StringComparison.InvariantCultureIgnoreCase)));
                if (mime.Key != null)
                {
                    item = mime;
                    return true;
                }
            }

            item = new KeyValuePair<string, MimeTypeDbItem>();
            return false;
        }

        public static bool TryGetFirstExtension(string mimeType, out string ext)
        {
            if (Items.TryGetValue(mimeType,out var item))
            {
                ext = item.Extensions != null && item.Extensions.Length > 0 ? item.Extensions[0] : null;
                return true;
            }
            ext = null;
            return false;
        }

        public static bool TryGetExtensions(string mimeType, out string[] ext)
        {
            if (Items.TryGetValue(mimeType,out var item))
            {
                ext = item.Extensions != null && item.Extensions.Length > 0 ? item.Extensions : Array.Empty<string>();
                return true;
            }
            ext = Array.Empty<string>();
            return false;
        }
    }
}