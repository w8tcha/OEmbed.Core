namespace OEmbed.Core.Tests.ProviderTests;

public class LoomTests : IProviderTests
{
   [TestCase("https://www.loom.com/share/43d05f362f734614a2e81b4694a3a523")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<LoomProvider>(url);
    }

#if NET481
    [Category("Integration")]
   [TestCase("https://www.loom.com/share/43d05f362f734614a2e81b4694a3a523")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [Category("Integration")]
   [TestCase("https://www.loom.com/share/43d05f362f734614a2e81b4694a3a523")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
