namespace OEmbed.Core.Tests.ProviderTests;

public class MixcloudTests : IProviderTests
{
   [TestCase("https://www.mixcloud.com/spartacus/party-time/")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<MixcloudProvider>(url);
    }

#if NET481
    [Category("Integration")]
   [TestCase("https://www.mixcloud.com/spartacus/party-time/")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [Category("Integration")]
   [TestCase("https://www.mixcloud.com/spartacus/party-time/")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
