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
        public IActionResult GetDepartments()
        {
            var departments = _serviceManager.DepartmentService.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{departmentId:guid}", Name = "GetDepartment")]
        public IActionResult GetDepartment(Guid departmentId)
        {
            var department = _serviceManager.DepartmentService.GetDepartment(departmentId);
            return Ok(department);
        }
        [HttpPost]
        public IActionResult CreateDepartment([FromBody] DepartmentForCreationDto departmentForCreationDto)
        {
            if (departmentForCreationDto is null)
                return BadRequest("DepartmentForCreationDto object is null");

            var createdDepertment = _serviceManager.DepartmentService.CreateDepartment(departmentForCreationDto);
            return CreatedAtRoute("GetDepartment", new { departmentId = createdDepertment.Id }, createdDepertment);
        }

        [HttpPut("departmentId:guid")]
        public IActionResult UpdateDepartment(Guid departmentId, [FromBody] DepartmentForUpdateDto departmentForUpdateDto)
        {
            if (departmentForUpdateDto is null)
                return BadRequest("DepartmentForUpdateDto object is null");            _serviceManager.DepartmentService.UpdateDepartment(departmentId, departmentForUpdateDto);
            return NoContent();
        }

        [HttpDelete("departmentId:guid")]
        public IActionResult DeleteDepartment(Guid departmentId)
        {
            _serviceManager.DepartmentService.DeleteDepartment(departmentId);
            return Ok();
        }

        [HttpPatch("{departmentId:guid}")]
        public IActionResult PartiallyUpdateDepartment(Guid departmentId, [FromBody] JsonPatchDocument<DepartmentForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _serviceManager.DepartmentService.GetDepartmentForPatch(departmentId);
            patchDoc.ApplyTo(result.departmentToPatch);

            _serviceManager.DepartmentService.SaveChangesForPatch(result.departmentToPatch, result.departmentEntity);
            return NoContent();
        }
    }
}
