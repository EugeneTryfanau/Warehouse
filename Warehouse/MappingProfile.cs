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
            CreateMap<DepartmentForCreationDto, Department>();
            CreateMap<Department, DepartmentForUpdateDto>();

            CreateMap<Worker, WorkerDto>();
            CreateMap<Worker, WorkerForCreationDto>();
            CreateMap<WorkerForCreationDto, Worker>();
            CreateMap<Worker, WorkerForUpdateDto>();

            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductForCreationDto>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<Product, ProductForUpdateDto>();
        }
    }
}
