using System.Text.Json.Serialization;

namespace MimeDb.Net.Items
{
    public class MimeTypeBasicItem
    {
        /// <summary>
        /// the default charset associated with this type, if any
        /// </summary>
        [JsonPropertyName("charset")]
        public string Charset { get; set; }
        /// <summary>
        /// whether a file of this type can be gzipped.
        /// leave out if you don't know, otherwise true/false to indicate whether the data represented by the type is typically compressible.
        /// </summary>
        [JsonPropertyName("compressible")]
        public bool Compressible { get; set; }
        /// <summary>
        ///  include an array of file extensions that are associated with the type.
        ///  known extensions associated with this mime type.
        /// </summary>
        [JsonPropertyName("extensions")]
        public string[] Extensions { get; set; }

        /// <summary>
        /// human-readable notes about the type, typically what the type is.
        /// </summary>
        [JsonPropertyName("notes")]
        public string Notes { get; set; }
    }
}
