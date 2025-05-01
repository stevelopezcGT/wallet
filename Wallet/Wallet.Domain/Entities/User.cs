namespace Wallet.Domain.Entities;

public class User : EntityBase
{
    public string UserName { get; set; }

    public string Password { get; set; }
}