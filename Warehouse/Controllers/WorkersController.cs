using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Warehouse.Controllers
{
    [Route("api/workers")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public WorkersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetDWorkers()
        {
            var workers = _serviceManager.WorkerService.GetAllWorkers();
            return Ok(workers);
        }

        [HttpGet("{workerId:guid}", Name = "WorkerById")]
        public IActionResult GetWorker(Guid workerId)
        {
            var worker = _serviceManager.WorkerService.GetWorker(workerId);
            return Ok(worker);
        }
        [HttpPost]
        public IActionResult CreateWorker([FromBody] WorkerForCreationDto workerForCreationDto)
        {
            if (workerForCreationDto is null)
                return BadRequest("WorkerForCreationDto object is null");

            var createdWorker = _serviceManager.WorkerService.CreateWorker(workerForCreationDto);
            return CreatedAtRoute("WorkerById", createdWorker);
        }

        [HttpPut("workerId:guid")]
        public IActionResult UpdateWorker(Guid workerId, [FromBody] WorkerForUpdateDto workerForUpdateDto)
        {
            if (workerForUpdateDto is null)
                return BadRequest("WorkerForUpdateDto object is null");            _serviceManager.WorkerService.UpdateWorker(workerId, workerForUpdateDto);
            return NoContent();
        }

        [HttpDelete("workerId:guid")]
        public IActionResult DeleteWorker(Guid workerId)
        {
            _serviceManager.WorkerService.DeleteWorker(workerId);
            return Ok();
        }
    }
}
