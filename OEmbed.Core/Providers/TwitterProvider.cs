﻿namespace OEmbed.Core.Providers;

public record TwitterProvider : Provider
{
    public TwitterProvider()
    {
        this.Name = "Twitter";
        this.Hosts =
        [
            "twitter.com",
            "www.twitter.com",
            "mobile.twitter.com",
            "x.com"
        ];

        this.AddMatches(@"/\w+/status(es)?/(\d+)(?:\?|/)?\S*");

        this.Endpoint = "https://publish.twitter.com/oembed";
    }
}