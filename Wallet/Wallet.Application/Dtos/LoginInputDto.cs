namespace Wallet.Application.Dtos;

/// <summary>
/// Represents the user's login credentials.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// The user's user name  used for logging in.
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// The user's password used for logging in.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}