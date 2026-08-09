namespace OEmbed.Core.Tests.ProviderTests;

public class SketchfabTests : IProviderTests
{
   [TestCase("https://sketchfab.com/3d-models/99bfe75ebd734fa3832a63e02e2cacf7")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
   [TestCase("https://sketchfab.com/3d-models/99bfe75ebd734fa3832a63e02e2cacf7")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
   [TestCase("https://sketchfab.com/3d-models/99bfe75ebd734fa3832a63e02e2cacf7")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
