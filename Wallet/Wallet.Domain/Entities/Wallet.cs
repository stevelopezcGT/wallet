namespace Wallet.Domain.Entities;

/// <summary>
/// Represents a wallet entity that holds financial information and transactions.
/// </summary>
public class Wallet : EntityBase
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

    /// <summary>
    /// Gets or sets the collection of transactions associated with the wallet.
    /// </summary>
    public virtual ICollection<Transaction> Transactions { get; set; } = [];
}