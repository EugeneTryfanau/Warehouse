using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Warehouse
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<Department, DepartmentForCreationDto>();
            CreateMap<Department, DepartmentForUpdateDto>();

            CreateMap<Worker, WorkerDto>();
            CreateMap<Worker, WorkerForCreationDto>();
            CreateMap<Worker, WorkerForUpdateDto>();

            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductForCreationDto>();
            CreateMap<Product, ProductForUpdateDto>();
        }
    }
}
