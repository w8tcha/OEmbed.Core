namespace OEmbed.Net.Tests.ProviderTests;

public class SoundCloudTests : IProviderTests
{
    [Theory]
    [InlineData("https://soundcloud.com/blackpinkofficial")]
    [InlineData("https://soundcloud.com/blackpinkofficial/whistle")]
    [InlineData("https://soundcloud.com/blackpinkofficial?utm_source=clipboard&utm_medium=text&utm_campaign=social_sharing")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481

    [Theory]
    [InlineData("https://soundcloud.com/blackpinkofficial")]
    [InlineData("https://soundcloud.com/blackpinkofficial/whistle")]
    [InlineData("https://soundcloud.com/blackpinkofficial?utm_source=clipboard&utm_medium=text&utm_campaign=social_sharing")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET6_0_OR_GREATER
    [Theory]
    [InlineData("https://soundcloud.com/blackpinkofficial")]
    [InlineData("https://soundcloud.com/blackpinkofficial/whistle")]
    [InlineData("https://soundcloud.com/blackpinkofficial?utm_source=clipboard&utm_medium=text&utm_campaign=social_sharing")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}