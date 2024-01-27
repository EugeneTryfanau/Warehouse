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

        public async Task<ProductDto> CreateProductAsync(Guid departmentId, ProductForCreationDto productForCreationDto)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var productEntity = _mapper.Map<Product>(productForCreationDto);
            _repositoryManager.Product.CreateProduct(departmentId, productEntity);
            await _repositoryManager.SaveAsync();

            var employeeToReturn = _mapper.Map<ProductDto>(productEntity);
            return employeeToReturn;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(Guid departmentId)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var productFromDb = await _repositoryManager.Product.GetAllProductsAsync(departmentId);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productFromDb);
            return productDto;
        }

        public async Task<ProductDto> GetProductAsync(Guid departmentId, Guid productId)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var productFromDb = await _repositoryManager.Product.GetProductAsync(departmentId, productId);
            if (productFromDb is null)
                throw new ProductNotFoundException(productId);

            var productDto = _mapper.Map<ProductDto>(productFromDb);
            return productDto;
        }

        public async Task UpdateProductAsync(Guid departmentId, Guid productId, ProductForUpdateDto productForUpdateDto)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var productEntity = await _repositoryManager.Product.GetProductAsync(departmentId, productId);
            if (productEntity is null)
                throw new ProductNotFoundException(productId);

            _mapper.Map(productForUpdateDto, productEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid departmentId, Guid productId)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var product = await _repositoryManager.Product.GetProductAsync(departmentId, productId);
            if (product is null)
                throw new ProductNotFoundException(productId);

            _repositoryManager.Product.DeleteProduct(product);
            await _repositoryManager.SaveAsync();
        }

        public async Task<(ProductForUpdateDto productToPatch, Product productEntity)> GetProductForPatchAsync(Guid departmentId, Guid productId)
        {
            var department = await _repositoryManager.Department.GetDepartmentAsync(departmentId);
            if (department is null)
                throw new DepartmentNotFoundException(departmentId);

            var product = await _repositoryManager.Product.GetProductAsync(departmentId, productId);
            if (product is null)
                throw new ProductNotFoundException(productId);

            var productToPatch = _mapper.Map<ProductForUpdateDto>(product);
            return (productToPatch, product);
        }

        public async Task SaveChangesForPatchAsync(ProductForUpdateDto productToPatch, Product productEntity)
        {
            _mapper.Map(productToPatch, productEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
