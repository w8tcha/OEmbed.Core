namespace OEmbed.Core.Tests.ProviderTests;

public class TedTests : IProviderTests
{
   [TestCase("https://www.ted.com/talks/simon_sinek_how_great_leaders_inspire_action")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
   [TestCase("https://www.ted.com/talks/simon_sinek_how_great_leaders_inspire_action")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
   [TestCase("https://www.ted.com/talks/simon_sinek_how_great_leaders_inspire_action")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
