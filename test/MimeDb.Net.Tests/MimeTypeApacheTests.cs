namespace MimeDb.Net.Tests;

public class MimeTypeApacheTests
{
    [Fact]
    public void LoadOk()
    {
        var nr = MimeTypeApache.Items.Count;
        Assert.Equal(1841, nr);
    }

    [Fact]
    public void TestMimeItem()
    {
        var mime = MimeTypeApache.Items["application/x-rar-compressed"];
        Assert.False(mime.Compressible);
        Assert.Single(mime.Extensions);
        Assert.Equal("rar", mime.Extensions[0]);
    }
}