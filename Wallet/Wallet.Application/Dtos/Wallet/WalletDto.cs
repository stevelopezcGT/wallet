namespace Wallet.Application.Dtos.Wallet;

/// <summary>
/// Represents a data transfer object for a wallet.
/// </summary>
public class WalletDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the wallet.
    /// </summary>
    public int Id { get; set; }

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

    /// <summary>
    /// Gets or sets the date and time when the wallet was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the date and time when the wallet was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<TransactionDto> Transactions { get; set; } = [];
}