using System.Text.Json.Serialization;

namespace MimeDb.Net;

[Serializable]
public class MimeTypeDbItem
{
    /// <summary>
    /// where the mime type is defined. If not set, it's probably a custom media type. <br />
    ///     <see href="https://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types">apache - Apache common media types</see> <br />
    ///     <see href="https://www.iana.org/assignments/media-types/media-types.xhtml">iana - IANA-defined media types</see> <br />
    ///     <see href="https://hg.nginx.org/nginx/raw-file/default/conf/mime.types">nginx - nginx media types</see> <br />
    /// include an array of URLs of where the MIME type and the associated extensions are sourced from.
    /// </summary>
    [JsonPropertyName("source")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MimeTypeItemDbSource Source { get; set; }
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