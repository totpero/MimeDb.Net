using System.Text.Json.Serialization;

namespace MimeDb.Net;

[Serializable]
public class MimeTypeDbItem
{
    /// <summary>
    /// include an array of URLs of where the MIME type and the associated extensions are sourced from. 
    /// This needs to be a primary source; links to type aggregating sites and Wikipedia are not acceptable.
    /// </summary>
    [JsonPropertyName("source")]
    public string Source { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("charset")]
    public string Charset { get; set; }
    /// <summary>
    /// leave out if you don't know, otherwise true/false to indicate whether the data represented by the type is typically compressible.
    /// </summary>
    [JsonPropertyName("compressible")]
    public bool Compressible { get; set; }
    /// <summary>
    ///  include an array of file extensions that are associated with the type.
    /// </summary>
    [JsonPropertyName("extensions")]
    public string[] Extensions { get; set; }
}