using AutoMapper;
using Contracts;
using Entities.Exceptions;
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
    }
}
