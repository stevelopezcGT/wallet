namespace Wallet.Application.Interfaces;

public interface IAuthenticationService
{
    Task<string> Login(string userName, string password);
}