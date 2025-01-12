namespace OEmbed.Core.Tests.ProviderTests;

public class TikTokTests : IProviderTests
{
    [Theory]
    [InlineData("https://m.tiktok.com/v/6934593663062265094.html")]
    [InlineData("https://www.tiktok.com/@faaaariii_/video/6934593663062265094")]
    [InlineData("https://www.tiktok.com/@faaaariii_/video/6934593663062265094?is_copy_url=1&is_from_webapp=v1")]
    [InlineData("https://www.tiktok.com/@faaaariii_")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481
    [Theory]
    [InlineData("https://m.tiktok.com/v/6934593663062265094.html")]
    [InlineData("https://www.tiktok.com/@faaaariii_/video/6934593663062265094")]
    [InlineData("https://www.tiktok.com/@faaaariii_/video/6934593663062265094?is_copy_url=1&is_from_webapp=v1")]
    [InlineData("https://www.tiktok.com/@faaaariii_")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET8_0_OR_GREATER
    [Theory]
    [InlineData("https://m.tiktok.com/v/6934593663062265094.html")]
    [InlineData("https://www.tiktok.com/@faaaariii_/video/6934593663062265094")]
    [InlineData("https://www.tiktok.com/@faaaariii_/video/6934593663062265094?is_copy_url=1&is_from_webapp=v1")]
    [InlineData("https://www.tiktok.com/@faaaariii_")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}