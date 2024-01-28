using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace WarehouseTests
{
    public class DepartmentServiceFake : IDepartmentService
    {
        public readonly List<DepartmentDto> _departments;

        public DepartmentServiceFake()
        {
            _departments = new List<DepartmentDto>()
            {
                new DepartmentDto(
                    new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    "TestDepartment1",
                    new List<ProductDto>()
                    {
                        new ProductDto(new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201"), "TestProduct1")
                    },
                    new List<WorkerDto>()),

                new DepartmentDto(
                    new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    "TestDepartment2",
                    new List<ProductDto>()
                    {
                        new ProductDto(new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae6f"), "TestProduct2")
                    },
                    new List<WorkerDto>()
                    {
                        new WorkerDto(new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae5f"), "TestWorkerFirstName1", "TestWorkerLastName1", new List<DepartmentDto>())
                    })
            };
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(DepartmentForCreationDto departmentForCreationDto)
        {
            var newDepartment = new DepartmentDto(Guid.NewGuid(), departmentForCreationDto.Name,
                new List<ProductDto>(),
                new List<WorkerDto>());
            _departments.Add(newDepartment);
            return newDepartment;
        }

        public async Task DeleteDepartmentAsync(Guid departmentId)
        {
            var departmentToDel = _departments.Where(d => d.Id == departmentId).SingleOrDefault();
            var result = _departments.Remove(departmentToDel);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            return _departments;
        }

        public async Task<DepartmentDto> GetDepartmentAsync(Guid departmentId)
        {
            var department = _departments.Where(d => d.Id == departmentId).SingleOrDefault();
            return department;
        }

        public async Task<(DepartmentForUpdateDto departmentToPatch, Department departmentEntity)> GetDepartmentForPatchAsync(Guid departmentId)
        {
            var departmentDb = _departments.Where(d => d.Id == departmentId).SingleOrDefault();
            Department department = new Department() { Id = departmentId, Name = departmentDb.Name, Products = new List<Product>(), Workers = new List<Worker>() };
            var departmentToPatch = new DepartmentForUpdateDto(departmentDb.Name,
                new List<ProductForUpdateDto>(),
                new List<WorkerForUpdateDto>());
            return (departmentToPatch, department);
        }

        public async Task SaveChangesForPatchAsync(DepartmentForUpdateDto departmentToPatch, Department departmentEntity)
        {

        }

        public async Task UpdateDepartmentAsync(Guid departmentId, DepartmentForUpdateDto departmentForUpdateDto)
        {
            var departmentDb = _departments.Where(d => d.Id == departmentId).SingleOrDefault();
            var departmentForUpdate = new DepartmentDto(departmentId, departmentForUpdateDto.Name,
                new List<ProductDto>(),
                new List<WorkerDto>());
            _departments.Remove(departmentDb);
            _departments.Add(departmentForUpdate);
        }
    }
}
