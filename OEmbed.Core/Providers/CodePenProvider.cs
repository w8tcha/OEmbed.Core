namespace OEmbed.Core.Providers;

/// <summary>
/// Class CodePenProvider.
/// Implements the <see cref="OEmbed.Core.Provider" />
/// Implements the <see cref="System.IEquatable{OEmbed.Core.Provider}" />
/// Implements the <see cref="System.IEquatable{OEmbed.Core.Providers.CodePenProvider}" />
/// </summary>
/// <seealso cref="OEmbed.Core.Provider" />
/// <seealso cref="System.IEquatable{OEmbed.Core.Provider}" />
/// <seealso cref="System.IEquatable{OEmbed.Core.Providers.CodePenProvider}" />
public record CodePenProvider : Provider
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CodePenProvider"/> class.
    /// </summary>
    public CodePenProvider()
    {
        this.Name = "CodePen";
        this.Hosts = ["codepen.io"];

        this.AddMatches(@"/(?:team/)?(?:[\w]+)/pen/([\w]+)/?");

        this.Endpoint = "https://codepen.io/api/oembed";
    }
}