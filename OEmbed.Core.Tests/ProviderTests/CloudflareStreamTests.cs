namespace OEmbed.Core.Tests.ProviderTests;

/// <summary>
/// Class CloudflareStreamTests.
/// Implements the <see cref="IProviderTests" />
/// </summary>
/// <seealso cref="IProviderTests" />
public class CloudflareStreamTests : IProviderTests
{
    [Theory]
    [InlineData("https://customer-aw5py76sw8wyqzmh.cloudflarestream.com/2463f6d3e06fa29710a337f5f5389fd8/")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481
    [Theory]
    [InlineData("https://customer-aw5py76sw8wyqzmh.cloudflarestream.com/2463f6d3e06fa29710a337f5f5389fd8/")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET8_0_OR_GREATER
    [Theory]
    [InlineData("https://customer-aw5py76sw8wyqzmh.cloudflarestream.com/2463f6d3e06fa29710a337f5f5389fd8/")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}