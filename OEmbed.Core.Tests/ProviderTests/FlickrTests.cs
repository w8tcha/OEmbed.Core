namespace OEmbed.Core.Tests.ProviderTests;

public class FlickrTests : IProviderTests
{
    
   [TestCase("https://flickr.com/photos/josbuurmansphotography/50553575881")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<FlickrProvider>(url);
    }

#if NET481
    [Category("Integration")]
    
   [TestCase("https://flickr.com/photos/josbuurmansphotography/50553575881")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [Category("Integration")]
    
   [TestCase("https://flickr.com/photos/josbuurmansphotography/50553575881")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}