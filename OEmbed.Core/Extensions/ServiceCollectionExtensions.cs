#if NET9_0_OR_GREATER
namespace OEmbed.Core.Extensions;

using Microsoft.Extensions.DependencyInjection;

using global::OEmbed.Core.Interfaces;

/// <summary>
/// Extension methods for setting up browser detection services in a <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    extension(IServiceCollection services)
    {
        /// <summary>
        /// Adds browser detection services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public IServiceCollection AddOEmbed()
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddScoped<IOEmbed, OEmbed>();

            return services;
        }
    }
}

#endif