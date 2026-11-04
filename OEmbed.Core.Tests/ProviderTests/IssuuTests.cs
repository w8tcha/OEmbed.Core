namespace OEmbed.Core.Tests.ProviderTests;

public class IssuuTests : IProviderTests
{ 
    [TestCase("https://issuu.com/nationalgeographicexpeditions/docs/23907_feb_journeys_catalog_-_high_res")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<IssuuProvider>(url);
    }

#if NET481
    [Category("Integration")]
    [Ignore("Ignore because it throws sometimes a 403")] 
    [TestCase("https://issuu.com/nationalgeographicexpeditions/docs/23907_feb_journeys_catalog_-_high_res")]
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
   [TestCase("https://issuu.com/nationalgeographicexpeditions/docs/23907_feb_journeys_catalog_-_high_res")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
