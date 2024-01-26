using Contracts;
using Entities.Models;

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

        public IEnumerable<Product> GetAllProducts(Guid departmentId)
        {
            return GetByCondition(p => p.DepartnentId.Equals(departmentId)).OrderBy(p => p.Name).ToList();
        }

        public Product? GetProduct(Guid departmentId, Guid productId)
        {
            return GetByCondition(p => p.DepartnentId.Equals(departmentId) && p.Id.Equals(productId)).SingleOrDefault();
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
