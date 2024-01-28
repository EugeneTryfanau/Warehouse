using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Warehouse.Controllers;

namespace WarehouseTests
{
    public class WorkersControllerTest
    {
        private readonly WorkersController _controller;
        private readonly IServiceManager _service;

        public WorkersControllerTest()
        {
            _service = new ServiceManagerFake();
            _controller = new WorkersController(_service);
        }

        [Fact]
        public void GetWorkers_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetWorkers().Result;
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetWorkers_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetWorkers().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<WorkerDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetWorker_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae5a");
            // Act
            var okResult = _controller.GetWorker(testGuid).Result;
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetWorker_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae5a");
            // Act
            var okResult = _controller.GetWorker(testGuid).Result as OkObjectResult;
            // Assert
            Assert.IsType<WorkerDto>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as WorkerDto).Id);
        }

        [Fact]
        public void CreateWorker_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            WorkerForCreationDto testItem = new WorkerForCreationDto("FirstName00", "LastName00", new List<DepartmentForCreationDto> { });
            // Act
            var createdResponse = _controller.CreateWorker(testItem).Result;
            // Assert
            Assert.IsType<CreatedAtRouteResult>(createdResponse);
        }

        [Fact]
        public void CreateWorker_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            WorkerForCreationDto testItem = new WorkerForCreationDto("FirstName00", "LastName00", new List<DepartmentForCreationDto> { });
            // Act
            var createdResponse = _controller.CreateWorker(testItem).Result as CreatedAtRouteResult;
            var item = createdResponse.Value as WorkerDto;
            // Assert
            Assert.IsType<WorkerDto>(item);
            Assert.Equal("FirstName00", item.FirstName);
            Assert.Equal("LastName00", item.LastName);
        }

        [Fact]
        public void DeleteWorker_ExistingGuidPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var existingGuid = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae5a");
            // Act
            var OkResultResponse = _controller.DeleteWorker(existingGuid).Result;
            // Assert
            Assert.IsType<OkResult>(OkResultResponse);
        }

        [Fact]
        public void DeleteWorker_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae5a");
            // Act
            var okResponse = _controller.DeleteWorker(existingGuid);
            // Assert
            Assert.Equal(2, _service.WorkerService.GetAllWorkersAsync().Result.Count());
        }

        [Fact]
        public void UpdateWorker_ExistingGuidPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var existingGuid = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae5a");
            WorkerForUpdateDto testItem = new WorkerForUpdateDto("NewFirstName", "NewLastName", new List<DepartmentForUpdateDto> { });
            // Act
            var noContentResponse = _controller.UpdateWorker(existingGuid, testItem).Result;
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void UpdateWorker_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae5a");
            WorkerForUpdateDto testItem = new WorkerForUpdateDto("NewFirstName", "NewLastName", new List<DepartmentForUpdateDto> { });
            // Act
            var noContentResponse = _controller.UpdateWorker(existingGuid, testItem).Result;
            // Assert
            Assert.Equal(3, _service.WorkerService.GetAllWorkersAsync().Result.Count());
            Assert.Equal("NewFirstName", _service.WorkerService.GetAllWorkersAsync().Result.Where(x => x.FirstName == "NewFirstName").Single().FirstName);
            Assert.Equal("NewLastName", _service.WorkerService.GetAllWorkersAsync().Result.Where(x => x.LastName == "NewLastName").Single().LastName);
        }
    }
}
