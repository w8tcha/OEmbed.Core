namespace OEmbed.Core.Tests.ProviderTests;

public class RedditTests : IProviderTests
{
    [Theory]
    [InlineData("https://www.reddit.com/r/Showerthoughts/comments/2safxv/we_should_start_keeping_giraffes_a_secret_from/cno7zic")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481

    [Theory]
    [InlineData("https://www.reddit.com/r/Showerthoughts/comments/2safxv/we_should_start_keeping_giraffes_a_secret_from/cno7zic")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET8_0_OR_GREATER
    [Theory]
    [InlineData("https://www.reddit.com/r/Showerthoughts/comments/2safxv/we_should_start_keeping_giraffes_a_secret_from/cno7zic")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}