﻿using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts(Guid departmentId);
        ProductDto GetProduct(Guid departmentId, Guid productId);
        ProductDto CreateProduct(Guid departmentId, ProductForCreationDto productForCreationDto);
        void UpdateProduct(Guid departmentId, Guid productId, ProductForUpdateDto productForUpdateDto);
        void DeleteProduct(Guid departmentId, Guid productId);

        (ProductForUpdateDto productToPatch, Product productEntity) GetProductForPatch(Guid departmentId, Guid productId);
        void SaveChangesForPatch(ProductForUpdateDto productToPatch, Product productEntity);

    }
}
