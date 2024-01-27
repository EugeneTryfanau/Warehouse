using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(Guid departmentId);
        Task<ProductDto> GetProductAsync(Guid departmentId, Guid productId);
        Task<ProductDto> CreateProductAsync(Guid departmentId, ProductForCreationDto productForCreationDto);
        Task UpdateProductAsync(Guid departmentId, Guid productId, ProductForUpdateDto productForUpdateDto);
        Task DeleteProductAsync(Guid departmentId, Guid productId);

        Task<(ProductForUpdateDto productToPatch, Product productEntity)> GetProductForPatchAsync(Guid departmentId, Guid productId);
        Task SaveChangesForPatchAsync(ProductForUpdateDto productToPatch, Product productEntity);

    }
}
