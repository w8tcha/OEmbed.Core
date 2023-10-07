namespace OEmbed.Core.Tests.ProviderTests;

public class FlickrTests : IProviderTests
{
    [Theory]
    [InlineData("https://flickr.com/photos/josbuurmansphotography/50553575881")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481

    [Theory]
    [InlineData("https://flickr.com/photos/josbuurmansphotography/50553575881")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET6_0_OR_GREATER
    [Theory]
    [InlineData("https://flickr.com/photos/josbuurmansphotography/50553575881")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}