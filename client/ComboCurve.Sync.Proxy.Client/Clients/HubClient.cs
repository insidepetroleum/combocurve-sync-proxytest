using ComboCurve.Sync.Proxy.Client.Utilities;
using ComboCurve.Sync.Proxy.Core.Models.Hubs;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;

namespace ComboCurve.Sync.Proxy.Client.Clients
{
    internal class HubClient
    {
        public static async Task CallNotificationHubMethods(Uri url, IConfiguration configuration)
        {
            Console.WriteLine($"\n--- 2/3 ---\nConfiguring SignalR connection {url}...\n");

            var connection = ProxyUtility.PrepareProxySignalRClient(url, configuration);
            await connection.StartAsync();

            connection.On("ReceiveMessageFromServer", () =>
            {
                Console.WriteLine("\n--- 3/3 ---\nReceived additional message from the server.");
                Console.WriteLine("\nEverything is OK.");
            });

            var response = await connection.InvokeAsync<SendMessageResponse>("SendMessage");

            Console.WriteLine($"Response from server received at {response.ReceivedAtUtc}");
            Console.WriteLine($"\"{response.ResponseMessage}\"");
        }
    }
}
