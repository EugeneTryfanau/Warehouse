using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateProduct(Guid departmentId, Product product)
        {
            product.DepartnentId = departmentId;
            Create(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(Guid departmentId)
        {
            return await GetByCondition(p => p.DepartnentId.Equals(departmentId)).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Product?> GetProductAsync(Guid departmentId, Guid productId)
        {
            return await GetByCondition(p => p.DepartnentId.Equals(departmentId) && p.Id.Equals(productId)).SingleOrDefaultAsync();
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }
    }
}
