using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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
        public async Task<IActionResult> GetDepartmentProducts(Guid departmentId)
        {
            var products = await _serviceManager.ProductService.GetAllProductsAsync(departmentId);
            return Ok(products);
        }

        [HttpGet("{productId:guid}", Name = "GetDepartmentProduct")]
        public async Task<IActionResult> GetDepartmentProduct(Guid departmentId, Guid productId)
        {
            var product = await _serviceManager.ProductService.GetProductAsync(departmentId, productId);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartmentProduct(Guid departmentId, [FromBody] ProductForCreationDto productForCreationDto)
        {
            if (productForCreationDto is null)
                return BadRequest("ProductForCreationDto object is null");

            var productToReturn = await _serviceManager.ProductService.CreateProductAsync(departmentId, productForCreationDto);
            return CreatedAtRoute("GetDepartmentProduct", new { departmentId, productId = productToReturn.Id }, productToReturn);

        }

        [HttpPut("{productId:guid}")]
        public async Task<IActionResult> UpdateDepartmentProduct(Guid departmentId, Guid productId, [FromBody] ProductForUpdateDto productForUpdateDto)
        {
            if (productForUpdateDto is null)
                return BadRequest("ProductForUpdateDto object is null");

            await _serviceManager.ProductService.UpdateProductAsync(departmentId, productId, productForUpdateDto);
            return NoContent();
        }

        [HttpDelete("{productId:guid}")]
        public async Task<IActionResult> DeleteDepartmentProducty(Guid departmentId, Guid productId)
        {
            await _serviceManager.ProductService.DeleteProductAsync(departmentId, productId);
            return NoContent();
        }

        [HttpPatch("{productId:guid}")]
        public async Task<IActionResult> PartiallyUpdateDepartmentProduct(Guid departmentId, Guid productId, [FromBody] JsonPatchDocument<ProductForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _serviceManager.ProductService.GetProductForPatchAsync(departmentId, productId);
            patchDoc.ApplyTo(result.productToPatch);

            await _serviceManager.ProductService.SaveChangesForPatchAsync(result.productToPatch, result.productEntity);
            return NoContent();
        }
    }
}
