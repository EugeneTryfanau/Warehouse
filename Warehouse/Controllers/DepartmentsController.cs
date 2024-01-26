﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{departmentId:guid}", Name = "DepartmentById")]
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
    }
}
