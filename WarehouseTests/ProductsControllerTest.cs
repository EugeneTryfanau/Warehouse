using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Warehouse.Controllers;

namespace WarehouseTests
{
    public class ProductsControllerTest
    {
        private readonly ProductsController _controller;
        private readonly IServiceManager _service;

        public ProductsControllerTest()
        {
            _service = new ServiceManagerFake();
            _controller = new ProductsController(_service);
        }

        [Fact]
        public void GetDepartmentProducts_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetDepartmentProducts(Guid.NewGuid()).Result;
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetDepartmentProducts_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetDepartmentProducts(Guid.NewGuid()).Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<ProductDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetDepartmentProduct_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201");
            // Act
            var okResult = _controller.GetDepartmentProduct(Guid.NewGuid(), testGuid).Result;
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetDepartmentProduct_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201");
            // Act
            var okResult = _controller.GetDepartmentProduct(Guid.NewGuid(), testGuid).Result as OkObjectResult;
            // Assert
            Assert.IsType<ProductDto>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as ProductDto).Id);
        }

        [Fact]
        public void CreateDepartmentProduct_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            ProductForCreationDto testItem = new ProductForCreationDto("NewProduct0");
            // Act
            var createdResponse = _controller.CreateDepartmentProduct(Guid.NewGuid(), testItem).Result;
            // Assert
            Assert.IsType<CreatedAtRouteResult>(createdResponse);
        }

        [Fact]
        public void CreateDepartmentProduct_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            ProductForCreationDto testItem = new ProductForCreationDto("NewProduct0");
            // Act
            var createdResponse = _controller.CreateDepartmentProduct(Guid.NewGuid(), testItem).Result as CreatedAtRouteResult;
            var item = createdResponse.Value as ProductDto;
            // Assert
            Assert.IsType<ProductDto>(item);
            Assert.Equal("NewProduct0", item.Name);
        }

        [Fact]
        public void DeleteDepartmentProduct_ExistingGuidPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201");
            // Act
            var OkResultResponse = _controller.DeleteDepartmentProduct(Guid.NewGuid(), existingGuid).Result;
            // Assert
            Assert.IsType<NoContentResult>(OkResultResponse);
        }

        [Fact]
        public void DeleteDepartmentProduct_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201");
            // Act
            var okResponse = _controller.DeleteDepartmentProduct(Guid.NewGuid(), existingGuid);
            // Assert
            Assert.Equal(2, _service.ProductService.GetAllProductsAsync(Guid.NewGuid()).Result.Count());
        }

        [Fact]
        public void UpdateDepartmentProduct_ExistingGuidPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201");
            ProductForUpdateDto testItem = new ProductForUpdateDto("CreateProductUpdate");
            // Act
            var noContentResponse = _controller.UpdateDepartmentProduct(Guid.NewGuid(), existingGuid, testItem).Result;
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void UpdateDepartmentProduct_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201");
            ProductForUpdateDto testItem = new ProductForUpdateDto("CreateProductUpdate");
            // Act
            var noContentResponse = _controller.UpdateDepartmentProduct(Guid.NewGuid(), existingGuid, testItem).Result;
            // Assert
            Assert.Equal(3, _service.ProductService.GetAllProductsAsync(Guid.NewGuid()).Result.Count());
            Assert.Equal("CreateProductUpdate", _service.ProductService.GetAllProductsAsync(Guid.NewGuid()).Result.Where(x => x.Name == "CreateProductUpdate").Single().Name);
        }
    }
}
