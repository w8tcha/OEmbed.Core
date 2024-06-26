﻿namespace OEmbed.Core.Providers;

public record GiphyProvider : Provider
{
    public GiphyProvider()
    {
        this.Name = "Giphy";
        this.Hosts =
        [
            "giphy.com",
            "www.giphy.com",
            "media.giphy.com"
        ];

        this.AddMatches(
            @"/(?:gifs|stickers|media|embed)/([\S]+)",
            @"/clips/([\S]+)");

        this.Endpoint = "https://giphy.com/services/oembed";
    }
}