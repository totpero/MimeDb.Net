namespace MimeDb.Net.Tests;

public class MimeTypeIanaTests
{
    [Fact]
    public void LoadOk()
    {
        var nr = MimeTypeIana.Items.Count;
        Assert.Equal(2195, nr);
    }

    [Fact]
    public void TestMimeItem()
    {
        var mime = MimeTypeIana.Items["application/1d-interleaved-parityfec"];
        Assert.False(mime.Compressible);
        Assert.Equal(2, mime.Sources.Length);
    }
}