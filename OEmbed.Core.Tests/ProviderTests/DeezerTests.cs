namespace OEmbed.Core.Tests.ProviderTests;

public class DeezerTests : IProviderTests
{
    
   [TestCase("https://www.deezer.com/us/album/217565572")]
   [TestCase("https://www.deezer.com/us/track/1286394242")]
   [TestCase("https://www.deezer.com/us/playlist/8664185942")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<DeezerProvider>(url);
    }

#if NET481
    [Category("Integration")]
    
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
    [Category("Integration")]
    
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