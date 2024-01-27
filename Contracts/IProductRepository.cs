using Entities.Models;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(Guid departmentId);
        Task<Product?> GetProductAsync(Guid departmentId, Guid productId);
        void CreateProduct(Guid departmentId, Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
