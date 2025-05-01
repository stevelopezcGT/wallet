namespace Wallet.Infraestructure.Data.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.Property(e => e.Amount)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0)
            .HasPrecision(18, 2)
            .IsRequired();
    }
}