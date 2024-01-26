using Entities.Models;

namespace Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(Guid departmentId);
        Product? GetProduct(Guid departmentId, Guid productId);
        void CreateProduct(Guid departmentId, Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
