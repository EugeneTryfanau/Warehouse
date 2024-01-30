using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetWorkers()
        {
            var workers = await _serviceManager.WorkerService.GetAllWorkersAsync();
            return Ok(workers);
        }

        [HttpGet("{workerId:guid}", Name = "GetWorker")]
        public async Task<IActionResult> GetWorker(Guid workerId)
        {
            var worker = await _serviceManager.WorkerService.GetWorkerAsync(workerId);
            return Ok(worker);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [Authorize("read:messages", Roles = "Administrator")]
        public async Task<IActionResult> CreateWorker([FromBody] WorkerForCreationDto workerForCreationDto)
        {
            if (workerForCreationDto is null)
                return BadRequest("WorkerForCreationDto object is null");

            var createdWorker = await _serviceManager.WorkerService.CreateWorkerAsync(workerForCreationDto);
            return CreatedAtRoute("GetWorker", new { workerId = createdWorker.Id }, createdWorker);
        }

        [HttpPut("workerId:guid")]
        [Authorize("read:messages", Roles = "Administrator")]
        public async Task<IActionResult> UpdateWorker(Guid workerId, [FromBody] WorkerForUpdateDto workerForUpdateDto)
        {
            if (workerForUpdateDto is null)
                return BadRequest("WorkerForUpdateDto object is null");            await _serviceManager.WorkerService.UpdateWorkerAsync(workerId, workerForUpdateDto);
            return NoContent();
        }

        [HttpDelete("workerId:guid")]
        [Authorize("read:messages", Roles = "Administrator")]
        public async Task<IActionResult> DeleteWorker(Guid workerId)
        {
            await _serviceManager.WorkerService.DeleteWorkerAsync(workerId);
            return Ok();
        }

        [HttpPatch("{workerId:guid}")]
        [Authorize("read:messages", Roles = "Administrator")]
        public async Task<IActionResult> PartiallyUpdateWorker(Guid workerId, [FromBody] JsonPatchDocument<WorkerForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _serviceManager.WorkerService.GetWorkerForPatchAsync(workerId);
            patchDoc.ApplyTo(result.workerToPatch);

            await _serviceManager.WorkerService.SaveChangesForPatchAsync(result.workerToPatch, result.workerEntity);
            return NoContent();
        }
    }
}
