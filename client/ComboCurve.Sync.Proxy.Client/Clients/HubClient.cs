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

            TaskCompletionSource completionSource = new();

            connection.On("ReceiveMessageFromServer", () =>
            {
                Console.WriteLine($"Server-sent message received as {DateTimeOffset.UtcNow}");
                Console.WriteLine("\nEverything is OK.");
                completionSource.SetResult();
            });

            var response = await connection.InvokeAsync<SendMessageResponse>("SendMessage");

            Console.WriteLine($"Response from server received at {response.ReceivedAtUtc}");
            Console.WriteLine($"\"{response.ResponseMessage}\"");

            Console.WriteLine("\n--- 3/3 ---\nWaiting for a message from server...");
            await completionSource.Task.WaitAsync(TimeSpan.FromSeconds(30));
        }
    }
}
