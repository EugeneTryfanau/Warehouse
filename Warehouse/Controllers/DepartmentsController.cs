using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Warehouse.Controllers
{
    [Route("api/[controller]")]
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
            try
            {
                var departments =
                _serviceManager.DepartmentService.GetAllDepartments();
                return Ok(departments);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
