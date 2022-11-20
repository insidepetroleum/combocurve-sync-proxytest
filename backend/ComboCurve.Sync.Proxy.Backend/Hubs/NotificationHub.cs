using ComboCurve.Sync.Proxy.Core.Models.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ComboCurve.Sync.Proxy.Backend.Hubs
{
    public class NotificationHub : Hub
    {
        public object SendMessage()
        {
            var caller = Clients.Caller;
            Task.Delay(2000).ContinueWith((_) =>
            {
                caller.SendAsync("ReceiveMessageFromServer", default);
            });

            return new SendMessageResponse
            {
                ResponseMessage = "Message received on the server. Will send an additional message shortly",
                ReceivedAtUtc = DateTimeOffset.UtcNow,
            };
        }
    }
}
