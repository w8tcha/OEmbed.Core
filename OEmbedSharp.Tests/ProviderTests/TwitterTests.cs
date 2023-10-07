namespace OEmbedSharp.Tests.ProviderTests;

public class TwitterTests : IProviderTests
{
    [Theory]
    [InlineData("http://twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("http://www.twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("https://twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("https://mobile.twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("https://twitter.com/panpianoatelier/status/1500450869590241286?s=20&t=piEth1McNILTUdD9Tf-48w")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481

    [Theory]
    [InlineData("http://twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("http://www.twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("https://twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("https://mobile.twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("https://twitter.com/panpianoatelier/status/1500450869590241286?s=20&t=piEth1McNILTUdD9Tf-48w")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET6_0_OR_GREATER
    [Theory]
    [InlineData("http://twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("http://www.twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("https://twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("https://mobile.twitter.com/panpianoatelier/status/1500450869590241286")]
    [InlineData("https://twitter.com/panpianoatelier/status/1500450869590241286?s=20&t=piEth1McNILTUdD9Tf-48w")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}