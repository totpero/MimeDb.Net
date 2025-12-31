using System;
using System.Collections.Generic;
using MimeDb.Net.Items;

namespace MimeDb.Net
{
    public static class MimeTypeIana
    {
        private const string FileName = "iana-types.json";

        private static readonly Lazy<IReadOnlyDictionary<string, MimeTypeItem>> Data = MimeTypeBase<MimeTypeItem>.GetLazyData(FileName);

        public static IReadOnlyDictionary<string, MimeTypeItem> Items => Data.Value;

    }
}