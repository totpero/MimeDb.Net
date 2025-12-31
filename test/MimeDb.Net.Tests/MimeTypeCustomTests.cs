namespace MimeDb.Net.Tests;

public class MimeTypeCustomTests
{
    [Fact]
    public void LoadOk()
    {
        var nr = MimeTypeCustom.Items.Count;
        Assert.Equal(228, nr);
    }

    [Fact]
    public void TestMimeItem()
    {
        var mime = MimeTypeCustom.Items["application/bdoc"];
        Assert.False(mime.Compressible);
        Assert.Equal(2, mime.Sources.Length);
    }
}