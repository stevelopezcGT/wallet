namespace Wallet.Application.Interfaces;

/// <summary>
/// Defines the contract for wallet-related operations.
/// </summary>
public interface IWalletService : IService<Wallet.Domain.Entities.Wallet>
{
    Task<Domain.Entities.Wallet> Transaction(int WalletId, TransactionRequestDto transactionRequest);

    Task<Domain.Entities.Wallet> GetHistoryById(int id);
}