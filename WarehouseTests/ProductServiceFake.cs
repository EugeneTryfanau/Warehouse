using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace WarehouseTests
{
    public class ProductServiceFake : IProductService
    {
        public readonly List<ProductDto> _products;

        public ProductServiceFake()
        {
            _products = new List<ProductDto>()
            {
                new ProductDto(new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), "TestProduct0"),
                new ProductDto(new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201"), "TestProduct1"),
                new ProductDto(new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c202"), "TestProduct2")
            };
        }

        public async Task<ProductDto> CreateProductAsync(Guid departmentId, ProductForCreationDto productForCreationDto)
        {
            var product = new ProductDto(Guid.NewGuid(), productForCreationDto.Name);
            _products.Add(product);
            return product;
        }

        public async Task DeleteProductAsync(Guid departmentId, Guid productId)
        {
            var existing = _products.First(a => a.Id == productId);
            _products.Remove(existing);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(Guid departmentId)
        {
            return _products;
        }

        public async Task<ProductDto> GetProductAsync(Guid departmentId, Guid productId)
        {
            return _products.FirstOrDefault(a => a.Id == productId);
        }

        public async Task<(ProductForUpdateDto productToPatch, Product productEntity)> GetProductForPatchAsync(Guid departmentId, Guid productId)
        {
            var productDb = _products.Where(d => d.Id == productId).SingleOrDefault();
            Product product = new Product() { Id = productId, Name = productDb.Name };
            var productToPatch = new ProductForUpdateDto(productDb.Name);
            return (productToPatch, product);
        }

        public async Task SaveChangesForPatchAsync(ProductForUpdateDto productToPatch, Product productEntity)
        {
            
        }

        public async Task UpdateProductAsync(Guid departmentId, Guid productId, ProductForUpdateDto productForUpdateDto)
        {
            var productDb = _products.Where(d => d.Id == productId).SingleOrDefault();
            var productForUpdate = new ProductDto(productId, productForUpdateDto.Name);
            _products.Remove(productDb);
            _products.Add(productForUpdate);
        }
    }
}
