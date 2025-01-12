using System.Linq;

namespace OEmbed.Core;

/// <summary>
/// Class Provider.
/// </summary>
public abstract record Provider
{
    /// <summary>
    /// Gets or sets the hosts.
    /// </summary>
    /// <value>The hosts.</value>
    public List<string> Hosts { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the matches.
    /// </summary>
    /// <value>The matches.</value>
    public List<Regex> Matches { get; set; } = [];

    /// <summary>
    /// Gets or sets the endpoint.
    /// </summary>
    /// <value>The endpoint.</value>
    public string Endpoint { get; set; }

    /// <summary>
    /// Gets or sets the HTML.
    /// </summary>
    /// <value>The HTML.</value>
    public string Html { get; set; }

    /// <summary>
    /// Determines whether this instance [can handle URL] the specified URI.
    /// </summary>
    /// <param name="uri">The URI.</param>
    /// <returns>bool.</returns>
    public virtual bool CanHandleUrl(Uri uri)
    {
        var contains = this.Hosts.Contains(uri.Host);

        return contains || this.Hosts.Select(hosts => uri.Host.Contains(hosts)).FirstOrDefault();
    }

    /// <summary>
    /// Matches the scheme.
    /// </summary>
    /// <param name="uri">The URI.</param>
    /// <returns>bool.</returns>
    public virtual Match MatchScheme(Uri uri)
    {
        var matchedScheme = this.Matches.Select(match => match.Match(uri.PathAndQuery))
                                .FirstOrDefault(check => check.Success) ??
                            this.Matches.Select(match => match.Match(uri.AbsoluteUri))
                                .FirstOrDefault(check => check.Success);

        return matchedScheme;
    }

    /// <summary>
    /// Gets the embed HTML for the Provider
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <param name="match">The match.</param>
    /// <param name="url">The URL.</param>
    /// <param name="hostUrl">The host URL.</param>
    /// <returns>OEmbed.Core.Response.</returns>
    public virtual Response GetHtml(Provider provider, Match match, string url, string hostUrl = null)
    {
        var response = new Response { Html = provider.Html.Replace("{url}", url), Type = ResponseType.Rich };

        return response;
    }

    /// <summary>
    /// Add matches.
    /// </summary>
    /// <param name="patterns">The patterns.</param>
    protected void AddMatches(params string[] patterns)
    {
        foreach (var pattern in patterns)
        {
            this.Matches.Add(new Regex($"^{pattern}$", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled));
        }
    }
}