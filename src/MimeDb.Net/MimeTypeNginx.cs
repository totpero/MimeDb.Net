using System;
using System.Collections.Generic;
using MimeDb.Net.Items;

namespace MimeDb.Net
{
    public static class MimeTypeNginx
    {
        private const string FileName = "nginx-types.json";

        private static readonly Lazy<IReadOnlyDictionary<string, MimeTypeItem>> Data =
            new Lazy<IReadOnlyDictionary<string, MimeTypeItem>>(() => MimeTypeBase<MimeTypeItem>.GetDataFromFile(FileName));

        public static IReadOnlyDictionary<string, MimeTypeItem> Items => Data.Value;
    }
}