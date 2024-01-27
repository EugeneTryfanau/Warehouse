using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Serilog;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;


        public DepartmentService(IRepositoryManager repositoryManager, ILogger logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(DepartmentForCreationDto departmentForCreationDto)
        {
            var department = _mapper.Map<Department>(departmentForCreationDto);

            _repositoryManager.Department.CreateDepartment(department);
            await _repositoryManager.SaveAsync();

            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return departmentDto;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _repositoryManager.Department.GetAllDepartmentsAsync();
            var departmentsDto = _mapper.Map<IEnumerable<DepartmentDto>>(departments);

            return departmentsDto;
        }

        public async Task<DepartmentDto> GetDepartmentAsync(Guid departmentId)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);
            var departmenrDto = _mapper.Map<DepartmentDto>(department);
            return departmenrDto;
        }

        public async Task UpdateDepartmentAsync(Guid departmentId, DepartmentForUpdateDto departmentForUpdateDto)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            _mapper.Map(departmentForUpdateDto, department);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteDepartmentAsync(Guid departmentId)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            _repositoryManager.Department.DeleteDepartment(department);
            await _repositoryManager.SaveAsync();
        }

        public async Task<(DepartmentForUpdateDto departmentToPatch, Department departmentEntity)> GetDepartmentForPatchAsync(Guid departmentId)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var departmentToPatch = _mapper.Map<DepartmentForUpdateDto>(department);
            return (departmentToPatch, department);
        }

        public async Task SaveChangesForPatchAsync(DepartmentForUpdateDto departmentToPatch, Department departmentEntity)
        {
            _mapper.Map(departmentToPatch, departmentEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
