namespace Wallet.Domain.Entities;

/// <summary>
/// Represents a financial transaction associated with a wallet.
/// </summary>
public class Transaction : EntityBase
{
    /// <summary>
    /// Gets or sets the identifier of the wallet associated with the transaction.
    /// </summary>
    public int WalletId { get; set; }

    /// <summary>
    /// Gets or sets the amount of the transaction.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the type of the transaction.
    /// Possible values are "Credit" or "Debit".
    /// </summary>
    public WalletType Type { get; set; } = WalletType.Credit;

    /// <summary>
    /// Gets or sets the wallet associated with the transaction.
    /// </summary>
    public virtual Wallet Wallet { get; set; } = null!;
}