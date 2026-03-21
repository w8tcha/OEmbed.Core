namespace OEmbed.Core.Tests.ProviderTests;

public class TwitterTests : IProviderTests
{
    
   [TestCase("http://twitter.com/panpianoatelier/status/1500450869590241286")]
   [TestCase("http://www.twitter.com/panpianoatelier/status/1500450869590241286")]
   [TestCase("https://twitter.com/panpianoatelier/status/1500450869590241286")]
   [TestCase("https://mobile.twitter.com/panpianoatelier/status/1500450869590241286")]
   [TestCase("https://twitter.com/panpianoatelier/status/1500450869590241286?s=20&t=piEth1McNILTUdD9Tf-48w")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
    
   [TestCase("https://x.com/SpaceX/status/1732824684683784516")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://x.com/SpaceX/status/1732824684683784516")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}