using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.ComponentModel.Design;

namespace Warehouse.Controllers
{
    [Route("api/departments/{departmentId}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetDepartmentProducts(Guid departmentId)
        {
            var products = _serviceManager.ProductService.GetAllProducts(departmentId);
            return Ok(products);
        }

        [HttpGet("{productId:guid}", Name = "GetDepartmentProduct")]
        public IActionResult GetDepartmentProduct(Guid departmentId, Guid productId)
        {
            var product = _serviceManager.ProductService.GetProduct(departmentId, productId);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid departmentId, [FromBody] ProductForCreationDto productForCreationDto)
        {
            if (productForCreationDto is null)
                return BadRequest("ProductForCreationDto object is null");

            var productToReturn = _serviceManager.ProductService.CreateProduct(departmentId, productForCreationDto);
            return CreatedAtRoute("GetDepartmentProduct", new { departmentId, productId = productToReturn.Id }, productToReturn);

        }

        [HttpPut("{productId:guid}")]
        public IActionResult UpdateEmployeeForCompany(Guid departmentId, Guid productId, [FromBody] ProductForUpdateDto productForUpdateDto)
        {
            if (productForUpdateDto is null)
                return BadRequest("EmployeeForUpdateDto object is null");

            _serviceManager.ProductService.UpdateProduct(departmentId, productId, productForUpdateDto);
            return NoContent();
        }

        [HttpDelete("{productId:guid}")]
        public IActionResult DeleteEmployeeForCompany(Guid departmentId, Guid productId)
        {
            _serviceManager.ProductService.DeleteProduct(departmentId, productId);
            return NoContent();
        }

    }
}
