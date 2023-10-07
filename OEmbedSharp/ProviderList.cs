namespace OEmbedSharp;

using System.Linq;

public class ProviderList
{
    /// <summary>
    /// Gets the oEmbed providers.
    /// </summary>
    /// <returns>List&lt;Provider&gt;.</returns>
    public List<Provider> GetProviders()
    {
       return new List<Provider>(typeof(Provider)
           .Assembly.GetTypes()
           .Where(t => t.IsSubclassOf(typeof(Provider)) && !t.IsAbstract)
           .Select(t => (Provider)Activator.CreateInstance(t)));
    }
}