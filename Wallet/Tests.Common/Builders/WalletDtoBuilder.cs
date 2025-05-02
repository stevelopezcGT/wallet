using Wallet.Application.Dtos.Wallet;

namespace Wallet.Tests.Common.Builders;

public class WalletDtoBuilder
{
    private int _id;

    public string _documentId { get; set; } = string.Empty;

    public string _name { get; set; } = string.Empty;

    public decimal _dalance { get; set; }

    public WalletDtoBuilder()
    {
        _id = 0;
        _documentId = null!;
        _name = null!;
        _dalance = 0;
    }

    public WalletDtoBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public WalletDtoBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public WalletDtoBuilder WithDocumentId(string documentId)
    {
        _documentId = documentId;
        return this;
    }

    public WalletDtoBuilder WithBalance(decimal balance)
    {
        _dalance = balance;
        return this;
    }

    public WalletDto Build()
    {
        return new WalletDto
        {
            Id = _id,
            Name = _name,
            DocumentId = _documentId,
            Balance = _dalance,
        };
    }
}