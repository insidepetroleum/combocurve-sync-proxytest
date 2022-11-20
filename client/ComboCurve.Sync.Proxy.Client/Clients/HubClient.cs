using ComboCurve.Sync.Proxy.Core.Models.Hubs;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboCurve.Sync.Proxy.Client.Clients
{
    internal class HubClient
    {
        public static async Task CallNotificationHubMethods(Uri baseUrl)
        {
            var signalRHubUrl = $"{baseUrl.AbsoluteUri}signalr";

            Console.WriteLine($"\n---\nConfiguring SignalR connection {signalRHubUrl}...\n");

            var connection = new HubConnectionBuilder()
                .WithUrl(signalRHubUrl)
                .Build();

            await connection.StartAsync();

            connection.On("ReceiveMessageFromServer", () =>
            {
                Console.WriteLine("\n---\nReceived additional message from the server.");
            });

            var response = await connection.InvokeAsync<SendMessageResponse>("SendMessage");

            Console.WriteLine($"Message Received at {response.ReceivedAtUtc}");
            Console.WriteLine($"\"{response.ResponseMessage}\"");

            //Console.WriteLine(responseContent);
        }
    }
}
