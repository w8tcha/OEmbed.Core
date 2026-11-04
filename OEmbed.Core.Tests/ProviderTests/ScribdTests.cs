namespace OEmbed.Core.Tests.ProviderTests;

public class ScribdTests : IProviderTests
{
    [TestCase("https://www.scribd.com/document/873342342/7-Best-Scribd-Downloaders-Online-Free-2025")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<ScribdProvider>(url);
    }

#if NET481
    [Category("Integration")]
    [Ignore("Ignore because it throws sometimes a 403")]
    [TestCase("https://www.scribd.com/document/873342342/7-Best-Scribd-Downloaders-Online-Free-2025")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [Category("Integration")]
    [Ignore("Ignore because it throws sometimes a 403")]
    [TestCase("https://www.scribd.com/document/873342342/7-Best-Scribd-Downloaders-Online-Free-2025")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
