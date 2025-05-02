namespace Wallet.Tests.Common.Builders;

public class WalletBuilder
{
    private int _id;

    public string _documentId { get; set; } = string.Empty;

    public string _name { get; set; } = string.Empty;

    public decimal _dalance { get; set; }

    public WalletBuilder()
    {
        _id = 0;
        _documentId = null!;
        _name = null!;
        _dalance = 0;
    }

    public WalletBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public WalletBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public WalletBuilder WithDocumentId(string documentId)
    {
        _documentId = documentId;
        return this;
    }

    public WalletBuilder WithBalance(decimal balance)
    {
        _dalance = balance;
        return this;
    }

    public Domain.Entities.Wallet Build()
    {
        return new Domain.Entities.Wallet
        {
            Id = _id,
            Name = _name,
            DocumentId = _documentId,
            Balance = _dalance,
        };
    }
}