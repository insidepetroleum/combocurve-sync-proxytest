using Microsoft.Extensions.Configuration;

namespace ComboCurve.Sync.Proxy.Client.Utilities
{
    internal class ConfigurationUtility
    {
        internal static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var baseUrl = configuration["serverUrl"];
            var useProxy = configuration["proxy:useProxy"];
            var useProxyCredentials = configuration["proxy:useProxyCredentials"];

            Console.WriteLine($"Server URL: {baseUrl}");
            Console.WriteLine($"Uses proxy: {useProxy}");
            Console.WriteLine($"Uses proxy credentials: {useProxyCredentials}");

            return configuration;
        }
    }
}
