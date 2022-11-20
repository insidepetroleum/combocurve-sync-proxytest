using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboCurve.Sync.Proxy.Core.Models.Hubs
{
    public class SendMessageResponse
    {
        public string ResponseMessage { get; set; } = null!;

        public DateTimeOffset ReceivedAtUtc { get; set; }
    }
}
