namespace OEmbed.Core.Providers;

public record RedditProvider : Provider
{
    public RedditProvider()
    {
        this.Name = "Reddit";
        this.Hosts =
        [
            "reddit.com",
            "www.reddit.com"
        ];

        this.AddMatches(@"(/r/|/user/)?(?(1)([\w:]{2,21}))(/comments/)?(?(3)(\w{5,6})(?:/[\w%\\\\-]+)?)?(?(4)/(\w{7}))?/?(\?)?(?(6)(\S+))?(\#)?(?(8)(\S+))?");

        this.Endpoint = "https://www.reddit.com/oembed";
    }
}