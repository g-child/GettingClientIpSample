using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GettingClientIpSample.Controllers
{
    [Route("")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var values = HttpContext.Request.Headers.Select(h => $"{h.Key} : {h.Value}").ToList();
            values.Add($"remoteIpAddress: {HttpContext.Connection.RemoteIpAddress}");
            return values;
        }
    }
}
