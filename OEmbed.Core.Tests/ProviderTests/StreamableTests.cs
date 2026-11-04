namespace OEmbed.Core.Tests.ProviderTests;

public class StreamableTests : IProviderTests
{
   [TestCase("https://streamable.com/hn8hq")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<StreamableProvider>(url);
    }

#if NET481
    [Category("Integration")]
   [TestCase("https://streamable.com/hn8hq")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [Category("Integration")]
   [TestCase("https://streamable.com/hn8hq")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
