namespace OEmbed.Core.Tests.ProviderTests;

public class DeezerTests : IProviderTests
{
    
   [TestCase("https://www.deezer.com/us/album/217565572")]
   [TestCase("https://www.deezer.com/us/track/1286394242")]
   [TestCase("https://www.deezer.com/us/playlist/8664185942")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
    
   [TestCase("https://www.deezer.com/us/album/217565572")]
   [TestCase("https://www.deezer.com/us/track/1286394242")]
   [TestCase("https://www.deezer.com/us/playlist/8664185942")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://www.deezer.com/us/album/217565572")]
   [TestCase("https://www.deezer.com/us/track/1286394242")]
   [TestCase("https://www.deezer.com/us/playlist/8664185942")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}