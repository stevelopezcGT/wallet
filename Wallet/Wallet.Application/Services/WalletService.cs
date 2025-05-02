namespace Wallet.Application.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;

    private readonly IMapper _mapper;

    public WalletService(IWalletRepository walletRepository, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
    }

    public async Task<Domain.Entities.Wallet> Create(Domain.Entities.Wallet wallet)
    {
        var walletExist = await _walletRepository.GetByAsync(x => x.DocumentId == wallet.DocumentId);
        if (walletExist is not null)
            throw new InvalidOperationException($"Ya existe una billetera para el document {wallet.DocumentId}");

        wallet.CreatedAt = DateTime.Now;
        wallet.UpdatedAt = DateTime.Now;
        return await _walletRepository.AddAsync(wallet);
    }

    public async Task Delete(int id)
    {
        var wallet = await _walletRepository.GetByIdAsync(id);
        if (wallet is not null)
        {
            await _walletRepository.RemoveAsync(wallet);
            return;
        }

        throw new NotFoundException(nameof(Domain.Entities.Wallet), id);
    }

    public async Task<Domain.Entities.Wallet> Edit(Domain.Entities.Wallet model)
    {
        var existingWallet = await _walletRepository.GetByAsync(f => f.DocumentId == model.DocumentId && f.Id != model.Id);
        if (existingWallet != null)
        {
            throw new InvalidOperationException($"Una billetera existe para el documento '{model.DocumentId}'.");
        }

        var wallet = await _walletRepository.GetByIdAsync(model.Id);

        if (wallet is not null)
        {
            wallet.Name = model.Name;
            wallet.UpdatedAt = DateTime.Now;
            return await _walletRepository.UpdateAsync(wallet);
        }

        throw new NotFoundException(nameof(Domain.Entities.Wallet), model.DocumentId);
    }

    public async Task<IEnumerable<Domain.Entities.Wallet>> GetAll()
    {
        return await _walletRepository.GetAllAsync();
    }

    public async Task<Domain.Entities.Wallet> GetById(int id)
    {
        var current = await _walletRepository.GetByIdAsync(id);

        if (current is not null)
        {
            return current;
        }

        throw new NotFoundException(nameof(Domain.Entities.Wallet), id);
    }

    public async Task<Domain.Entities.Wallet> Transaction(int walletId, TransactionRequestDto transactionRequest)
    {
        var current = await _walletRepository.GetByIdAsync(walletId);
        if (current is not null)
        {
            if (current.Balance + transactionRequest.Amount * (transactionRequest.TransactionType == TransactionType.Debit ? -1 : 1) < 0)
            {
                throw new InvalidOperationException($"No hay suficiente saldo en la billetera {current.Name}");
            }

            current.Balance += transactionRequest.Amount * (transactionRequest.TransactionType == TransactionType.Debit ? -1 : 1);
            current.UpdatedAt = DateTime.Now;
            return await _walletRepository.UpdateAsync(current);
        }

        throw new NotFoundException(nameof(Domain.Entities.Wallet), walletId);
    }
}