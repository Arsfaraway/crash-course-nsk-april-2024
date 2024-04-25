namespace Market.Services;

public interface IUserAuthenticator
{
    Task<Guid?> AuthenticateUser(string login, string password);
    
}