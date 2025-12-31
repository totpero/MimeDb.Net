using MimeDb.Net.Items;

namespace MimeDb.Net.Tests;

public class MimeDbTests
{
    [Fact]
    public void LoadOk()
    {
        var nr = MimeDb.Items.Count;
        Assert.Equal(2580, nr);
    } 
    
    [Fact]
    public void TestMimeItem()
    {
        var mime = MimeDb.Items["application/vnd.syncml.dm+xml"];
        Assert.True(mime.Compressible);
        Assert.Equal(MimeTypeDbItemSource.Iana, mime.Source);
    }

    /// <summary>
    /// should set audio/x-flac with extension=flac
    /// </summary>
    [Fact]
    public void TestMimeTypeItemExtension()
    {
        var mime = MimeDb.Items["audio/x-flac"];
        Assert.Equal("flac", mime.Extensions[0]);
    }

    [Fact]
    public void TestTryGetExtensions()
    {
        var exists = MimeDb.TryGetExtensions("image/jpeg", out var extensions);
        Assert.True(exists);
        Assert.Single(extensions, "jpeg");
    }

    [Fact]
    public void TestTryGetMimeType()
    {
        var exists = MimeDb.TryGetFileMimeType("filename.jpeg", out var mimetype);
        Assert.True(exists);
        Assert.Single(mimetype.Value.Extensions, "jpeg");
        Assert.Equal("image/jpeg", mimetype.Key);
    }

}