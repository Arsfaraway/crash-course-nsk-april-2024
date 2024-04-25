using Market.Models;

namespace Market.DAL.InterfacesRepository.Carts;

internal interface ICartsRepository
{
    Task<Cart?> GetCartAsync(Guid customerId);

    Task AddProductToCartAsync(Guid customerId, Guid productId);
    
    Task RemoveProductFromCartAsync(Guid customerId, Guid productId);
    
    Task ClearAll(Guid customerId);
}