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
            CreateMap<Department, DepartmentForCreationDto>().ReverseMap();
            CreateMap<Department, DepartmentForUpdateDto>().ReverseMap();

            CreateMap<Worker, WorkerDto>();
            CreateMap<Worker, WorkerForCreationDto>().ReverseMap();
            CreateMap<Worker, WorkerForUpdateDto>().ReverseMap();

            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductForCreationDto>().ReverseMap();
            CreateMap<Product, ProductForUpdateDto>().ReverseMap();
        }
    }
}
