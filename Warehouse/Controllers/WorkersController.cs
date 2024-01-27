using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{workerId:guid}", Name = "GetWorker")]
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
            return CreatedAtRoute("GetWorker", new { workerId = createdWorker.Id }, createdWorker);
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

        [HttpPatch("{workerId:guid}")]
        public IActionResult PartiallyUpdateWorker(Guid workerId, [FromBody] JsonPatchDocument<WorkerForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _serviceManager.WorkerService.GetWorkerForPatch(workerId);
            patchDoc.ApplyTo(result.workerToPatch);

            _serviceManager.WorkerService.SaveChangesForPatch(result.workerToPatch, result.workerEntity);
            return NoContent();
        }
    }
}
