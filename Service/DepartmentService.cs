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

        public DepartmentDto CreateDepartment(DepartmentForCreationDto departmentForCreationDto)
        {
            var department = _mapper.Map<Department>(departmentForCreationDto);

            _repositoryManager.Department.CreateDepartment(department);
            _repositoryManager.Save();

            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return departmentDto;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _repositoryManager.Department.GetAllDepartments();
            var departmentsDto = _mapper.Map<IEnumerable<DepartmentDto>>(departments);

            return departmentsDto;
        }

        public DepartmentDto GetDepartment(Guid departmentId)
        {
            var department = _repositoryManager.Department.GetDepartment(departmentId);

            if (department is null)
                throw new DepartmentNotFoundException(departmentId);
            var departmenrDto = _mapper.Map<DepartmentDto>(department);
            return departmenrDto;
        }

        public void UpdateDepartment(Guid departmentId, DepartmentForUpdateDto departmentForUpdate)
        {
            var department = _repositoryManager.Department.GetDepartment(departmentId);

            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            _mapper.Map(departmentForUpdate, department);
            _repositoryManager.Save();

        }

        public void DeleteDepartment(Guid departmentId)
        {
            var department = _repositoryManager.Department.GetDepartment(departmentId);

            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            _repositoryManager.Department.DeleteDepartment(department);
            _repositoryManager.Save();
        }
    }
}
