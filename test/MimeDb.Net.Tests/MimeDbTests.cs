namespace MimeDb.Net.Tests;

public class MimeDbTests
{
    [Fact]
    public void LoadOk()
    {
        var nr = MimeDb.MimeTypeItems.Count;
        Assert.NotEqual(0, nr);
    } 
    
    [Fact]
    public void TestMimeItem()
    {
        var mime = MimeDb.MimeTypeItems["application/vnd.syncml.dm+xml"];
        Assert.True(mime.Compressible);
        Assert.Equal("iana", mime.Source);
    }
}