namespace OEmbed.Core.Tests.Helpers;

/// <summary>
/// Offline assertions about which provider handles a URL.
/// </summary>
public static class ProviderAssert
{
    /// <summary>
    /// Asserts that <paramref name="url"/> is picked up by <typeparamref name="TProvider"/> (host match)
    /// and that one of its URL schemes matches, i.e. <see cref="OEmbed.EmbedAsync"/> would not bail out with <c>null</c>.
    /// </summary>
    public static void Handles<TProvider>(string url)
        where TProvider : Provider
    {
        var embed = new OEmbed();
        var uri = new Uri(url);

        embed.CanEmbed(url).Should().BeTrue();

        var provider = embed.Providers.Find(p => p.CanHandleUrl(uri));

        provider.Should().BeOfType<TProvider>();

        var match = provider.MatchScheme(uri);

        match.Should().NotBeNull();
        match.Success.Should().BeTrue($"one of the {provider.Name} URL schemes should match {url}");
    }
}
