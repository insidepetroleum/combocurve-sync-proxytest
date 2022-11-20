using ComboCurve.Sync.Proxy.Core.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace ComboCurve.Sync.Proxy.Backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        [Route("value")]
        [HttpGet]
        public object Get()
        {
            return new ApiResponse
            {
                Message = "This is a valid response",
                UtcDateTime = DateTime.UtcNow
            };
        }
    }
}