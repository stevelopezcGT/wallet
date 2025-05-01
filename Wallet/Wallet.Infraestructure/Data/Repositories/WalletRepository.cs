namespace Wallet.Infrastructure.Data.Repositories;

public class WalletRepository : Repository<Wallet.Domain.Entities.Wallet>, IWalletRepository
{
    private readonly AppDbContext _context;

    public WalletRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}