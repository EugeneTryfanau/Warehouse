using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Warehouse.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public DepartmentsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _serviceManager.DepartmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{departmentId:guid}", Name = "GetDepartment")]
        public async Task<IActionResult> GetDepartment(Guid departmentId)
        {
            var department = await _serviceManager.DepartmentService.GetDepartmentAsync(departmentId);
            return Ok(department);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentForCreationDto departmentForCreationDto)
        {
            if (departmentForCreationDto is null)
                return BadRequest("DepartmentForCreationDto object is null");

            var createdDepertment = await _serviceManager.DepartmentService.CreateDepartmentAsync(departmentForCreationDto);
            return CreatedAtRoute("GetDepartment", new { departmentId = createdDepertment.Id }, createdDepertment);
        }

        [HttpPut("departmentId:guid")]
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<IActionResult> UpdateDepartment(Guid departmentId, [FromBody] DepartmentForUpdateDto departmentForUpdateDto)
        {
            if (departmentForUpdateDto is null)
                return BadRequest("DepartmentForUpdateDto object is null");            await _serviceManager.DepartmentService.UpdateDepartmentAsync(departmentId, departmentForUpdateDto);
            return NoContent();
        }

        [HttpDelete("departmentId:guid")]
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<IActionResult> DeleteDepartment(Guid departmentId)
        {
            await _serviceManager.DepartmentService.DeleteDepartmentAsync(departmentId);
            return Ok();
        }

        [HttpPatch("{departmentId:guid}")]
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<IActionResult> PartiallyUpdateDepartment(Guid departmentId, [FromBody] JsonPatchDocument<DepartmentForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _serviceManager.DepartmentService.GetDepartmentForPatchAsync(departmentId);
            patchDoc.ApplyTo(result.departmentToPatch);

            await _serviceManager.DepartmentService.SaveChangesForPatchAsync(result.departmentToPatch, result.departmentEntity);
            return NoContent();
        }
    }
}
