using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Serilog;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, ILogger logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public ProductDto CreateProduct(Guid departmentId, ProductForCreationDto productForCreationDto)
        {
            var department = _repositoryManager.Department.GetDepartment(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var productEntity = _mapper.Map<Product>(productForCreationDto);
            _repositoryManager.Product.CreateProduct(departmentId, productEntity);
            _repositoryManager.Save();

            var employeeToReturn = _mapper.Map<ProductDto>(productEntity);
            return employeeToReturn;
        }

        public IEnumerable<ProductDto> GetAllProducts(Guid departmentId)
        {
            var department = _repositoryManager.Department.GetDepartment(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var productFromDb = _repositoryManager.Product.GetAllProducts(departmentId);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productFromDb);
            return productDto;
        }

        public ProductDto GetProduct(Guid departmentId, Guid productId)
        {
            var department = _repositoryManager.Department.GetDepartment(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var productFromDb = _repositoryManager.Product.GetProduct(departmentId, productId);
            if (productFromDb is null)
                throw new ProductNotFoundException(productId);

            var productDto = _mapper.Map<ProductDto>(productFromDb);
            return productDto;
        }

        public void UpdateProduct(Guid departmentId, Guid productId, ProductForUpdateDto productForUpdateDto)
        {
            var department = _repositoryManager.Department.GetDepartment(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var productEntity = _repositoryManager.Product.GetProduct(departmentId, productId);
            if (productEntity is null)
                throw new ProductNotFoundException(productId);

            _mapper.Map(productForUpdateDto, productEntity);
            _repositoryManager.Save();
        }

        public void DeleteProduct(Guid departmentId, Guid productId)
        {
            var department = _repositoryManager.Department.GetDepartment(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var product = _repositoryManager.Product.GetProduct(departmentId, productId);
            if (product is null)
                throw new ProductNotFoundException(productId);

            _repositoryManager.Product.DeleteProduct(product);
            _repositoryManager.Save();
        }

        public (ProductForUpdateDto productToPatch, Product productEntity) GetProductForPatch(Guid departmentId, Guid productId)
        {
            var department = _repositoryManager.Department.GetDepartment(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var product = _repositoryManager.Product.GetProduct(departmentId, productId);
            if (product is null)
                throw new ProductNotFoundException(productId);

            var productToPatch = _mapper.Map<ProductForUpdateDto>(product);
            return (productToPatch, product);
        }

        public void SaveChangesForPatch(ProductForUpdateDto productToPatch, Product productEntity)
        {
            _mapper.Map(productToPatch, productEntity);
            _repositoryManager.Save();
        }
    }
}
