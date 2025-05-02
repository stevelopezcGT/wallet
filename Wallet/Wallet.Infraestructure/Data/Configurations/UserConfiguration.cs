namespace Wallet.Infraestructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User { Id = 1, UserName = "walletUser", Password = "passwordC0mplex", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );
    }
}