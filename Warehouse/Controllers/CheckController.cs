using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        private readonly ILogger<CheckController> _logger;

        public CheckController(ILogger<CheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCheck")]
        public void GetCheck()
        {
            try
            {
                _logger.LogInformation("Test log");
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, ex);
                throw;
            }
        }
    }
}
