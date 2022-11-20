using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboCurve.Sync.Proxy.Core.Models.Api
{
    public class ApiResponse
    {
        public string Message { get; set; } = null!;

        public DateTime UtcDateTime { get; set; }
    }
}
