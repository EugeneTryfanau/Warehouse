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

        [HttpGet("{id:guid}")]
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

            return CreatedAtRoute("DepartmentById", createdDepertment);
        }

        [HttpPut]
        public IActionResult UpdateDepartment(Guid departmentId, [FromBody] DepartmentForUpdateDto departmentForUpdateDto)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(Guid departmentId)
        {
            _serviceManager.DepartmentService.DeleteDepartment(departmentId);
            return Ok();
        }
    }
}
