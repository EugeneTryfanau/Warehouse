using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Warehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public WorkersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
    }
}
