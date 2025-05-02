namespace Wallet.Application.Dtos.Wallet;

public class TransactionRequestDto
{
    public decimal Amount { get; set; }

    public TransactionType TransactionType { get; set; }
}