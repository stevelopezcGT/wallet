namespace Wallet.Tests.Common.Mothers;

public static class WallteMother
{
    public static Domain.Entities.Wallet Create(int id, string name, string documentId, decimal balance)
    {
        return new WalletBuilder()
            .WithId(id)
            .WithName(name)
            .WithDocumentId(documentId)
            .WithBalance(balance)
            .Build();
    }

    public static Domain.Entities.Wallet GetDefault()
    {
        return new Domain.Entities.Wallet() { Id = 1, Name = "default", DocumentId = "xxxxx-k", Balance = 0 };
    }

    public static List<Domain.Entities.Wallet> GetWalletList()
    {
        return
        [
            Create(1, "XXXXX", "YYYYYY", 0 )
        ];
    }

    public static List<Domain.Entities.Wallet> GetWalletList(int quantity)
    {
        var walletList = new List<Domain.Entities.Wallet>()
        {
            Create(0, "", "",0)
        };

        var firmFaker = new Faker<Domain.Entities.Wallet>()
            .RuleFor(o => o.Id, f => f.IndexFaker + 1)
            .RuleFor(o => o.Name, f => $"Name{f.IndexFaker + 1}");

        walletList.AddRange(firmFaker.Generate(quantity));

        return walletList;
    }

    public static List<Domain.Entities.Wallet> GetRandomFirmList(int quantity)
    {
        var roleFaker = new Faker<Domain.Entities.Wallet>()
            .RuleFor(o => o.Id, f => f.IndexFaker + 1)
            .RuleFor(o => o.Name, f => f.Name.Random.AlphaNumeric(50));

        return roleFaker.Generate(quantity);
    }
}