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
        return this.Hosts.Contains(uri.Host);
    }

    /// <summary>
    /// Matches the scheme.
    /// </summary>
    /// <param name="uri">The URI.</param>
    /// <returns>bool.</returns>
    public virtual bool MatchScheme(Uri uri)
    {
        return this.Matches.Exists(match => match.Match(uri.PathAndQuery).Success);
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