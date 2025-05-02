namespace Wallet.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Wallet.Domain.Entities.Wallet, WalletDto>().ReverseMap();
        CreateMap<CreateWalletDto, Wallet.Domain.Entities.Wallet>();
        CreateMap<UpdateWalletDto, Wallet.Domain.Entities.Wallet>();
    }
}