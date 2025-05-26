using Microsoft.AspNetCore.Mvc;

namespace A3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController(ILogger<HealthCheckController> logger) : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger = logger;

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("Health check executado às {date}.", DateTime.UtcNow);
            return Ok(new { status = "Healthy boy!" });
        }
    }
}
