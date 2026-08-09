namespace OEmbed.Core.Tests.ProviderTests;

public class BlueskyTests : IProviderTests
{
   [TestCase("https://bsky.app/profile/chriskenny.bsky.social/post/3loagm2phgk2t")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
   [TestCase("https://bsky.app/profile/chriskenny.bsky.social/post/3loagm2phgk2t")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
   [TestCase("https://bsky.app/profile/chriskenny.bsky.social/post/3loagm2phgk2t")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
