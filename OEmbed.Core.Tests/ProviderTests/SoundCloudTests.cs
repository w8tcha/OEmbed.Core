namespace OEmbed.Core.Tests.ProviderTests;

public class SoundCloudTests : IProviderTests
{
    
   [TestCase("https://soundcloud.com/blackpinkofficial")]
   [TestCase("https://soundcloud.com/blackpinkofficial/whistle")]
   [TestCase("https://soundcloud.com/blackpinkofficial?utm_source=clipboard&utm_medium=text&utm_campaign=social_sharing")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481

    
   [TestCase("https://soundcloud.com/blackpinkofficial")]
   [TestCase("https://soundcloud.com/blackpinkofficial/whistle")]
   [TestCase("https://soundcloud.com/blackpinkofficial?utm_source=clipboard&utm_medium=text&utm_campaign=social_sharing")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://soundcloud.com/blackpinkofficial")]
   [TestCase("https://soundcloud.com/blackpinkofficial/whistle")]
   [TestCase("https://soundcloud.com/blackpinkofficial?utm_source=clipboard&utm_medium=text&utm_campaign=social_sharing")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}