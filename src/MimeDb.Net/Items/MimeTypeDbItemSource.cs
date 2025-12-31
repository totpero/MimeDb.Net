namespace MimeDb.Net.Items
{
    public enum MimeTypeDbItemSource
    {
        /// <summary>
        /// https://www.iana.org/assignments/media-types/media-types.xhtml
        /// </summary>
        Iana,
        /// <summary>
        /// https://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types
        /// </summary>
        Apache,
        /// <summary>
        /// https://hg.nginx.org/nginx/raw-file/default/conf/mime.types
        /// </summary>
        Nginx
    }
}