using Wallet.Application.Dtos.Wallet;
using Wallet.Domain.Define;

namespace Wallet.Tests.Common.Mothers;

public static class WalletDtoMother
{
    public static WalletDto Create(int id, string name, string documentId, decimal balance)
    {
        return new WalletDtoBuilder()
            .WithId(id)
            .WithName(name)
            .WithDocumentId(documentId)
            .WithBalance(balance)
            .Build();
    }

    public static WalletDto GetDefault()
    {
        return new WalletDto() { Id = 1, Name = "default", DocumentId = "xxxxx-k", Balance = 0 };
    }

    public static WalletDto GetEmptyWallet()
    {
        return Create(0, null!, null!, 0);
    }

    public static WalletDto GetWalletithMaxLengths()
    {
        return Create(1, "A".PadRight(ValidationConst.MaxFieldLength + 1, 'A'), "", 0);
    }

    public static List<WalletDto> GetWalletList()
    {
        return [
            GetDefault()
        ];
    }
}