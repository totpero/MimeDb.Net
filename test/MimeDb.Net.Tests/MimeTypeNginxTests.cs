namespace MimeDb.Net.Tests;

public class MimeTypeNginxTests
{
    [Fact]
    public void LoadOk()
    {
        var nr = MimeTypeNginx.Items.Count;
        Assert.Equal(82, nr);
    }

    [Fact]
    public void TestMimeItem()
    {
        var mime = MimeTypeNginx.Items["application/octet-stream"];
        Assert.False(mime.Compressible);
        Assert.Equal(10,mime.Extensions.Length);
        Assert.Equal("bin", mime.Extensions[0]);
    }
}