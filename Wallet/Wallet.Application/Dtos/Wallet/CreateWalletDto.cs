namespace Wallet.Application.Dtos.Wallet;

public class CreateWalletDto
{
    /// <summary>
    /// Gets or sets the document identifier associated with the wallet.
    /// </summary>
    public string DocumentId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the wallet.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current balance of the wallet.
    /// </summary>
    public decimal Balance { get; set; }
}