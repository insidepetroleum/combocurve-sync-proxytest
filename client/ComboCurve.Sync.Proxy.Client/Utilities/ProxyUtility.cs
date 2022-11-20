using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace ComboCurve.Sync.Proxy.Client.Utilities
{
    internal class ProxyUtility
    {
        internal static HttpClient PrepareProxyHttpClient(Uri url, IConfiguration configuration)
        {
            var useProxy = bool.Parse(configuration["proxy:useProxy"]!);
            if (!useProxy)
            {
                return new HttpClient
                {
                    BaseAddress = url
                };
            }

            var httpClientHandler = new HttpClientHandler
            {
                Proxy = PrepareProxyConfiguration(configuration)
            };

            return new HttpClient(httpClientHandler, true)
            {
                BaseAddress = url
            };
        }

        internal static HubConnection PrepareProxySignalRClient(Uri baseUrl, IConfiguration configuration)
        {
            var signalRHubUrl = $"{baseUrl.AbsoluteUri}signalr";

            var useProxy = bool.Parse(configuration["proxy:useProxy"]!);
            if (!useProxy)
            {
                return new HubConnectionBuilder()
                    .WithUrl(signalRHubUrl)
                    .Build();
            }

            var proxy = PrepareProxyConfiguration(configuration);

            return new HubConnectionBuilder()
                .WithUrl(signalRHubUrl, transports => transports.Proxy = proxy)
                .Build();
        }

        private static IWebProxy PrepareProxyConfiguration(IConfiguration configuration)
        {
            var proxyServerScheme = configuration["proxy:proxyServerScheme"];
            var proxyServerAddress = configuration["proxy:proxyServerAddress"];
            var proxyServerPort = configuration["proxy:proxyServerPort"];

            var proxy = new WebProxy
            {
                Address = new Uri($"{proxyServerScheme}://{proxyServerAddress}:{proxyServerPort}"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false
            };

            Console.WriteLine($"Setting up proxy server at {proxy.Address}");

            var useProxyCredentials = bool.Parse(configuration["proxy:useProxyCredentials"]!);

            if (useProxyCredentials)
            {
                var proxyUsername = configuration["proxy:proxyUsername"];
                var proxyPassword = configuration["proxy:proxyPassword"];

                Console.WriteLine("Setting up proxy server credentials.");

                proxy.Credentials = new NetworkCredential(proxyUsername, proxyPassword);
            }

            return proxy;
        }
    }
}
