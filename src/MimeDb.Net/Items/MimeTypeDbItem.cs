using System;
using System.Text.Json.Serialization;

namespace MimeDb.Net.Items
{
    [Serializable]
    public class MimeTypeDbItem : MimeTypeBasicItem
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
        public MimeTypeDbItemSource Source { get; set; }

    }
}