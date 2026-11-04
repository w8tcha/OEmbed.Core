namespace OEmbed.Core.Tests.ProviderTests;

public class BlueskyTests : IProviderTests
{
   [TestCase("https://bsky.app/profile/chriskenny.bsky.social/post/3loagm2phgk2t")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<BlueskyProvider>(url);
    }

#if NET481
    [Category("Integration")]
   [TestCase("https://bsky.app/profile/chriskenny.bsky.social/post/3loagm2phgk2t")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [Category("Integration")]
   [TestCase("https://bsky.app/profile/chriskenny.bsky.social/post/3loagm2phgk2t")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
