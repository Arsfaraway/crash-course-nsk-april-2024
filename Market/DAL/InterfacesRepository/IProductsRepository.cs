using Market.Enums;
using Market.Models;

namespace Market.DAL.InterfacesRepository.Products;

internal interface IProductsRepository
{
    Task<IReadOnlyCollection<Product>> GetProductsAsync(
        string? name = null,
        Guid? sellerId = null,
        ProductCategory? category = null,
        int skip = 0,
        int take = 50);

    Task<Product?> GetProductAsync(Guid productId);

    Task UpdateProductAsync(Guid productId, ProductUpdateInfo updateInfo);

    Task DeleteProductAsync(Guid productId);
}