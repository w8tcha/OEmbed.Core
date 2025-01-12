namespace OEmbed.Core.Tests.ProviderTests;

public class GitHubGistTests : IProviderTests
{
    [Theory]
    [InlineData("https://gist.github.com/skabber/54099")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481

    [Theory]
    [InlineData("https://gist.github.com/skabber/54099")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET8_0_OR_GREATER
    [Theory]
    [InlineData("https://gist.github.com/skabber/54099")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}