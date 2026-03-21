namespace OEmbed.Core.Tests.ProviderTests;

public class FlickrTests : IProviderTests
{
    
   [TestCase("https://flickr.com/photos/josbuurmansphotography/50553575881")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
    
   [TestCase("https://flickr.com/photos/josbuurmansphotography/50553575881")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://flickr.com/photos/josbuurmansphotography/50553575881")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}