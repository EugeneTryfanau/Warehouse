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
            CreateMap<Worker, WorkerDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}
