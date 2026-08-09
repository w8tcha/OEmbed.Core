namespace OEmbed.Core.Tests.ProviderTests;

public class LoomTests : IProviderTests
{
   [TestCase("https://www.loom.com/share/43d05f362f734614a2e81b4694a3a523")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
   [TestCase("https://www.loom.com/share/43d05f362f734614a2e81b4694a3a523")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
   [TestCase("https://www.loom.com/share/43d05f362f734614a2e81b4694a3a523")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
