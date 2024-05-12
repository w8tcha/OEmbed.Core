﻿namespace OEmbed.Core.Tests.ProviderTests;

public class TwitchTests : IProviderTests
{
    [Theory]
    [InlineData("https://www.twitch.tv/therealknossi")]
    [InlineData("https://www.twitch.tv/videos/2141265767")]
    [InlineData("https://www.twitch.tv/therealknossi/clip/DiligentRelatedBisonVoteYea-5mkamtYyocJOfu79")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481
    [Theory]
    [InlineData("https://www.twitch.tv/therealknossi")]
    [InlineData("https://www.twitch.tv/videos/2141265767")]
    [InlineData("https://www.twitch.tv/therealknossi/clip/DiligentRelatedBisonVoteYea-5mkamtYyocJOfu79")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET7_0_OR_GREATER
    [Theory]
    [InlineData("https://www.twitch.tv/therealknossi")]
    [InlineData("https://www.twitch.tv/videos/2141265767")]
    [InlineData("https://www.twitch.tv/therealknossi/clip/DiligentRelatedBisonVoteYea-5mkamtYyocJOfu79")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}