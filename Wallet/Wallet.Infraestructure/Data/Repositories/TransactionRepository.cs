namespace Wallet.Infrastructure.Data.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}