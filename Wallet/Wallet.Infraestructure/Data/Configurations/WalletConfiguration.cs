namespace Wallet.Infraestructure.Data.Configurations;

public class WalletConfiguration : IEntityTypeConfiguration<Wallet.Domain.Entities.Wallet>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Wallet> builder)
    {
        builder.Property(e => e.Balance)
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2)
            .IsRequired();
    }
}