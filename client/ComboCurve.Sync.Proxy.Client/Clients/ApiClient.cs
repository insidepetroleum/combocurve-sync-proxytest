using ComboCurve.Sync.Proxy.Client.Utilities;
using Microsoft.Extensions.Configuration;

namespace ComboCurve.Sync.Proxy.Client.Clients
{
    internal class ApiClient
    {
        public static async Task CallApi(Uri url, IConfiguration configuration)
        {
            Console.WriteLine($"\n--- 1/3 ---\nCalling conventional API {url}...\n");

            using var client = ProxyUtility.PrepareProxyHttpClient(url, configuration);

            var response = await client.GetAsync("/api/value");

            Console.WriteLine($"Response status code: {response.StatusCode}");
            
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseContent);
        }
    }
}
