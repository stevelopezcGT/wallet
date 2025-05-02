namespace Wallet.Tests.Common.Mapping;

public static class MapperCreator
{
    public static IMapper CreateMapper()
    {
        var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
        return mapperConfig.CreateMapper();
    }
}