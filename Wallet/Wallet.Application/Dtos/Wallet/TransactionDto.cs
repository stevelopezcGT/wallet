namespace Wallet.Application.Dtos.Wallet;

public class TransactionDto
{
    public decimal Amount { get; set; }

    public string TransactionType { get; set; }

    public DateTime TransactionDate { get; set; }
}