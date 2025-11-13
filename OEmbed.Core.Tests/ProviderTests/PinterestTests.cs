namespace OEmbed.Core.Tests.ProviderTests;

public class PinterestTests : IProviderTests
{
    [Theory]
    [InlineData("https://www.pinterest.com/pin/6896205669260457/")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481

    [Theory]
    [InlineData("https://www.pinterest.com/pin/6896205669260457/")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET9_0_OR_GREATER
    [Theory]
    [InlineData("https://www.pinterest.com/pin/6896205669260457/")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}