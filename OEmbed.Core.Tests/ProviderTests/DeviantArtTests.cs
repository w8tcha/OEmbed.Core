namespace OEmbed.Core.Tests.ProviderTests;

public class DeviantArtTests : IProviderTests
{
    
   [TestCase("https://www.deviantart.com/wlop/art/Sunshine2-905829772")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
    
   [TestCase("https://www.deviantart.com/wlop/art/Sunshine2-905829772")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://www.deviantart.com/wlop/art/Sunshine2-905829772")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}