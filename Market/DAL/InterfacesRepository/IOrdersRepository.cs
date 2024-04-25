using Market.Models;

namespace Market.DAL.InterfacesRepository.Orders;

internal interface IOrdersRepository
{
    Task CreateOrderAsync(Order order);

    Task ChangeStateForOrder(Guid orderId, OrderState newState);

    Task<IReadOnlyCollection<Order>> GetOrdersForSeller(Guid sellerId, bool onlyCreated);
}