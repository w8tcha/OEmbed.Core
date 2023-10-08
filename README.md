# OEmbed.Core

![oembed](https://github.com/w8tcha/OEmbedSharp/assets/722575/1a3d14e1-8249-4fa3-a230-789127f12c2b)

C# [oEmbed](https://oembed.com) consumer library for .NET Framwork 4.8.1 and .NET (Core) 6/7

[![NuGet](https://img.shields.io/nuget/v/OEmbed.Core.svg)](https://nuget.org/packages/OEmbed.Core)

[![build dotnet](https://github.com/w8tcha/OEmbed.Core/actions/workflows/build.yml/badge.svg)](https://github.com/w8tcha/OEmbed.Core/actions/workflows/build.yml)

### Supported Providers
* CodePen.io
* DailyMotion.com
* Deezer.com
* Deviantart.com
* Facebook.com
* Flickr.com
* Giphy.com
* Gist.GitHub.com
* Instagram.com
* Pinterest.com
* Reddit.com
* Soundcloud.com
* Spotify.com
* Tiktok.com
* Twitter.com
* Vimeo.com
* Youtube.com

## Install
via [NuGet](https://www.nuget.org/packages/OEmbedSharp):
```
PM> Install-Package OEmbedSharp
```

## DI configuration

```C#
services.AddOEmbed();
```

## Usage .NET Core

* Inject `IOEmbed` throught constructor injection.
* Call EmbedAsync().

For example:
```C#
// Returns Provider Result of null if provider not found.
var result = await oEmbed.EmbedAsync("url");
```

## Usage .NET Framework

```C#
// Returns Provider Result of null if provider not found.
var embed = new OEmbed();

var result = embed.Embed("url");
```

## License
[Apache](LICENSE)
