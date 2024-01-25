using Contracts;
using Entities.Models;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return GetAll().OrderBy(p => p.Name).ToList();
        }

        public Product? GetProduct(Guid productId)
        {
            return GetByCondition(p => p.Id.Equals(productId)).SingleOrDefault();
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
