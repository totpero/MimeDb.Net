using System;
using System.Collections.Generic;
using MimeDb.Net.Items;

namespace MimeDb.Net
{
    public static class MimeTypeApache
    {
        private const string FileName = "apache-types.json";

        private static readonly Lazy<IReadOnlyDictionary<string, MimeTypeBasicItem>> Data = MimeTypeBase<MimeTypeBasicItem>.GetLazyData(FileName);

        public static IReadOnlyDictionary<string, MimeTypeBasicItem> Items => Data.Value;
    }
}