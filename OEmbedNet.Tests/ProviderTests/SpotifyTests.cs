namespace OEmbed.Net.Tests.ProviderTests;

public class SpotifyTests : IProviderTests
{
    [Theory]
    [InlineData("https://open.spotify.com/artist/3HqSLMAZ3g3d5poNaI7GOU")]
    [InlineData("https://open.spotify.com/album/2xEH7SRzJq7LgA0fCtTlxH")]
    [InlineData("https://open.spotify.com/track/4Dr2hJ3EnVh2Aaot6fRwDO?si=66ea03b84a8940b5")]
    [InlineData("https://open.spotify.com/playlist/37i9dQZF1DX0y9CwEpdGpz")]
    [InlineData("https://open.spotify.com/show/6RLX4Ns3kRUQiJi7RZl4NA")]
    [InlineData("https://open.spotify.com/episode/5xpsJbqTd09Lk5fZocYeOw")]
    [InlineData("https://open.spotify.com/user/spotify/playlist/37i9dQZF1DX0y9CwEpdGpz")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481

    [Theory]
    [InlineData("https://open.spotify.com/artist/3HqSLMAZ3g3d5poNaI7GOU")]
    [InlineData("https://open.spotify.com/album/2xEH7SRzJq7LgA0fCtTlxH")]
    [InlineData("https://open.spotify.com/track/4Dr2hJ3EnVh2Aaot6fRwDO?si=66ea03b84a8940b5")]
    [InlineData("https://open.spotify.com/playlist/37i9dQZF1DX0y9CwEpdGpz")]
    [InlineData("https://open.spotify.com/show/6RLX4Ns3kRUQiJi7RZl4NA")]
    [InlineData("https://open.spotify.com/episode/5xpsJbqTd09Lk5fZocYeOw")]
    [InlineData("https://open.spotify.com/user/spotify/playlist/37i9dQZF1DX0y9CwEpdGpz")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET6_0_OR_GREATER
    [Theory]
    [InlineData("https://open.spotify.com/artist/3HqSLMAZ3g3d5poNaI7GOU")]
    [InlineData("https://open.spotify.com/album/2xEH7SRzJq7LgA0fCtTlxH")]
    [InlineData("https://open.spotify.com/track/4Dr2hJ3EnVh2Aaot6fRwDO?si=66ea03b84a8940b5")]
    [InlineData("https://open.spotify.com/playlist/37i9dQZF1DX0y9CwEpdGpz")]
    [InlineData("https://open.spotify.com/show/6RLX4Ns3kRUQiJi7RZl4NA")]
    [InlineData("https://open.spotify.com/episode/5xpsJbqTd09Lk5fZocYeOw")]
    [InlineData("https://open.spotify.com/user/spotify/playlist/37i9dQZF1DX0y9CwEpdGpz")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}