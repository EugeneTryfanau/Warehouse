using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Warehouse.Controllers;

namespace WarehouseTests
{
    public class DepartmentsControllerTest
    {
        private readonly DepartmentsController _controller;
        private readonly IServiceManager _service;

        public DepartmentsControllerTest()
        {
            _service = new ServiceManagerFake();
            _controller = new DepartmentsController(_service);
        }

        [Fact]
        public void GetDepartments_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetDepartments().Result;
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetDepartments_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetDepartments().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<DepartmentDto>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetDepartment_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f");
            // Act
            var okResult = _controller.GetDepartment(testGuid).Result;
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetDepartment_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f");
            // Act
            var okResult = _controller.GetDepartment(testGuid).Result as OkObjectResult;
            // Assert
            Assert.IsType<DepartmentDto>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as DepartmentDto).Id);
        }

        [Fact]
        public void CreateDepartment_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            DepartmentForCreationDto testItem = new DepartmentForCreationDto("CreateDepartmentCheck1", new List<ProductForCreationDto> { }, new List<WorkerForCreationDto> { });
            // Act
            var createdResponse = _controller.CreateDepartment(testItem).Result;
            // Assert
            Assert.IsType<CreatedAtRouteResult>(createdResponse);
        }

        [Fact]
        public void CreateDepartment_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            DepartmentForCreationDto testItem = new DepartmentForCreationDto("CreateDepartmentCheck1", new List<ProductForCreationDto> { }, new List<WorkerForCreationDto> { });
            // Act
            var createdResponse = _controller.CreateDepartment(testItem).Result as CreatedAtRouteResult;
            var item = createdResponse.Value as DepartmentDto;
            // Assert
            Assert.IsType<DepartmentDto>(item);
            Assert.Equal("CreateDepartmentCheck1", item.Name);
        }

        [Fact]
        public void DeleteDepartment_ExistingGuidPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            // Act
            var OkResultResponse = _controller.DeleteDepartment(existingGuid).Result;
            // Assert
            Assert.IsType<OkResult>(OkResultResponse);
        }

        [Fact]
        public void DeleteDepartment_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            // Act
            var okResponse = _controller.DeleteDepartment(existingGuid);
            // Assert
            Assert.Equal(1, _service.DepartmentService.GetAllDepartmentsAsync().Result.Count());
        }

        [Fact]
        public void UpdateDepartment_ExistingGuidPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            DepartmentForUpdateDto testItem = new DepartmentForUpdateDto("CreateDepartmentCheck222", new List<ProductForUpdateDto> { }, new List<WorkerForUpdateDto> { });
            // Act
            var noContentResponse = _controller.UpdateDepartment(existingGuid, testItem).Result;
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void UpdateDepartment_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            DepartmentForUpdateDto testItem = new DepartmentForUpdateDto("CreateDepartmentCheck222", new List<ProductForUpdateDto> { }, new List<WorkerForUpdateDto> { });
            // Act
            var noContentResponse = _controller.UpdateDepartment(existingGuid, testItem).Result;
            // Assert
            Assert.Equal(2, _service.DepartmentService.GetAllDepartmentsAsync().Result.Count());
            Assert.Equal("CreateDepartmentCheck222", _service.DepartmentService.GetAllDepartmentsAsync().Result.Where(x => x.Name == "CreateDepartmentCheck222").Single().Name);
        }
    }
}