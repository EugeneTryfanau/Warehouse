using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Warehouse.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public DepartmentsController(IServiceManager services)
        {
            _serviceManager = services;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _serviceManager.DepartmentService.GetAllDepartments();
            return Ok(departments);
        }

    }
}
