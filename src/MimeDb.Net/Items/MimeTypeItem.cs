using System;
using System.Text.Json.Serialization;

namespace MimeDb.Net.Items
{
    [Serializable]
    public class MimeTypeItem : MimeTypeBasicItem
    {
        [JsonPropertyName("sources")]
        public string[] Sources { get; set; }
    }
}