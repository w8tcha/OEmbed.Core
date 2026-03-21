namespace OEmbed.Core.Tests.ProviderTests;

public class TwitchTests : IProviderTests
{
    
   [TestCase("https://www.twitch.tv/therealknossi")]
   [TestCase("https://www.twitch.tv/videos/2141265767")]
   [TestCase("https://www.twitch.tv/therealknossi/clip/DiligentRelatedBisonVoteYea-5mkamtYyocJOfu79")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
    
   [TestCase("https://www.twitch.tv/therealknossi")]
   [TestCase("https://www.twitch.tv/videos/2141265767")]
   [TestCase("https://www.twitch.tv/therealknossi/clip/DiligentRelatedBisonVoteYea-5mkamtYyocJOfu79")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url, "localhost");

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://www.twitch.tv/therealknossi")]
   [TestCase("https://www.twitch.tv/videos/2141265767")]
   [TestCase("https://www.twitch.tv/therealknossi/clip/DiligentRelatedBisonVoteYea-5mkamtYyocJOfu79")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url, "localhost");

        actual.Should().NotBeNull();
    }
#endif
}