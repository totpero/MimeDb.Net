using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MimeDb.Net.Items;

namespace MimeDb.Net
{
    public static class MimeDb
    {
        private const string FileName = "db.json";

        private static readonly Lazy<IReadOnlyDictionary<string, MimeTypeDbItem>> Data = MimeTypeBase<MimeTypeDbItem>.GetLazyData(FileName);

        public static IReadOnlyDictionary<string, MimeTypeDbItem> Items => Data.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool TryGetFileMimeType(string fileName, out KeyValuePair<string, MimeTypeDbItem> item)
        {
            var ext = Path.GetExtension(fileName);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mimeType"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mimeType"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
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