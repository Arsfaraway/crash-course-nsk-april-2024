using Market.Models;

namespace Market.DAL.InterfacesRepository.Users;

public interface IUsersRepository
{
    Task<Guid> CreateUser(string name, string login, string password);
    Task<User?> GetUser(string login);
    Task SetSellerState(Guid userId, bool newState);
    
}