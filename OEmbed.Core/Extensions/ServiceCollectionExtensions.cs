#if NET7_0_OR_GREATER
namespace OEmbed.Core.Extensions;

using Microsoft.Extensions.DependencyInjection;

using global::OEmbed.Core.Interfaces;

/// <summary>
/// Extension methods for setting up browser detection services in a <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds browser detection services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddOEmbed(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddScoped<IOEmbed, OEmbed>();

        return services;
    }
}

#endif