namespace OEmbed.Core.Tests.ProviderTests;

/// <summary>
/// Interface Provider Tests
/// </summary>
public interface IProviderTests
{
    void CanEmbedTest(string url);

#if NET481
    void EmbedTest(string url);
#endif

#if NET7_0_OR_GREATER
    Task EmbedAsyncTest(string url);
#endif
}