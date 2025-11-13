namespace OEmbed.Core.Tests.ProviderTests;

public class DeezerTests : IProviderTests
{
    [Theory]
    [InlineData("https://www.deezer.com/us/album/217565572")]
    [InlineData("https://www.deezer.com/us/track/1286394242")]
    [InlineData("https://www.deezer.com/us/playlist/8664185942")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481
    [Theory]
    [InlineData("https://www.deezer.com/us/album/217565572")]
    [InlineData("https://www.deezer.com/us/track/1286394242")]
    [InlineData("https://www.deezer.com/us/playlist/8664185942")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET9_0_OR_GREATER
    [Theory]
    [InlineData("https://www.deezer.com/us/album/217565572")]
    [InlineData("https://www.deezer.com/us/track/1286394242")]
    [InlineData("https://www.deezer.com/us/playlist/8664185942")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}