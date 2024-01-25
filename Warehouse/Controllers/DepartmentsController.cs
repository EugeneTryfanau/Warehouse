using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
    }
}
