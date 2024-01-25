using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;


        public DepartmentService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            try
            {
                var departments = _repositoryManager.Department.GetAllDepartments();

                var departmentsDto = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
                return departmentsDto;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong in the { nameof(GetAllDepartments)} service method { ex}");
                throw;
            }
        }
    }
}
