namespace OEmbedSharp;

using System.Linq;

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
    public List<Regex> Matches { get; set; } = new();

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

    public virtual bool CanHandleUrl(Uri uri)
    {
        return this.Hosts.Contains(uri.Host);
    }

    public virtual bool MatchScheme(Uri uri)
    {
        return this.Matches.Any(match => match.Match(uri.PathAndQuery).Success);
    }

    protected void AddMatches(params string[] patterns)
    {
        foreach (var pattern in patterns)
        {
            this.Matches.Add(new Regex($"^{pattern}$", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled));
        }
    }
}