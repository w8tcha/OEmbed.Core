namespace OEmbed.Core.Interfaces;

/// <summary>
/// OEmbed Interface
/// </summary>
public interface IOEmbed
{
    /// <summary>
    /// Check if url matches any Provider Host address
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns><c>true</c> if this instance can embed the specified URL; otherwise, <c>false</c>.</returns>
    bool CanEmbed(string url);

    /// <summary>
    /// Check if url matches any Provider Host address
    /// </summary>
    /// <param name="uri">The URI.</param>
    /// <returns><c>true</c> if this instance can embed the specified URI; otherwise, <c>false</c>.</returns>
    bool CanEmbed(Uri uri);

#if NET481
    /// <summary>
    /// Embeds the specified URL.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <param name="hostUrl">The host URL.</param>
    /// <returns>Response.</returns>
    Response Embed(string url, string hostUrl = null);
#endif

#if NET8_0_OR_GREATER
    /// <summary>
    /// Embeds the specified URL.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <param name="hostUrl">The host URL.</param>
    /// <returns>Response.</returns>
    Task<Response> EmbedAsync(string url, string hostUrl = null);
#endif
}