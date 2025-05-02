using AutoMapper;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Wallet.Api.Controllers;
using Wallet.Application.Dtos.Wallet;
using Wallet.Application.Interfaces;
using Wallet.Tests.Common.Mapping;
using Wallet.Tests.Common.Mothers;

namespace Api.UnitTest.Controllers;

public class WalletsControllerTests
{
    private WalletsController _walletsController = null!;

    private Mock<IWalletService> _mockWalletService = null!;

    private IMapper _mapper = null!;

    private static EquivalencyAssertionOptions<WalletDto> ExcludeProperties(EquivalencyAssertionOptions<WalletDto> options)
    {
        return options;
    }

    [SetUp]
    public void Setup()
    {
        _mockWalletService = new Mock<IWalletService>();
        _mapper = MapperCreator.CreateMapper();

        _walletsController = new WalletsController(_mockWalletService.Object, _mapper)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            }
        };
    }

    [Test]
    public async Task GetAll_WhenCalled_ReturnsOkWithListOfFirms()
    {
        // Arrange
        var walletResponseExpected = WallteMother.GetWalletList();
        var walletsDtoExpected = WalletDtoMother.GetWalletList();

        _mockWalletService.Setup(x => x.GetAll()).ReturnsAsync(walletResponseExpected);

        // Act
        var response = await _walletsController.Get() as ObjectResult;

        // Asserts
        response.Should().NotBeNull();
        response!.StatusCode.Should().Be(StatusCodes.Status200OK);
        var walletsDtoResponse = response!.Value as List<WalletDto>;
        walletsDtoResponse.Should().NotBeNull();

        _mockWalletService.Verify(x => x.GetAll(), Times.Once());
    }

    [Test]
    public async Task Get_WhenIdIsValid_ReturnsOkWithFirm()
    {
        // Arrange
        var walletResponseExpected = WallteMother.GetDefault();
        var walletDtoResponseExpected = WalletDtoMother.GetDefault();
        var id = walletResponseExpected.Id;

        _mockWalletService.Setup(x => x.GetById(id)).ReturnsAsync(walletResponseExpected);

        // Act
        var response = await _walletsController.Get(id) as ObjectResult;

        // Asserts
        response.Should().NotBeNull();
        response!.StatusCode.Should().Be(StatusCodes.Status200OK);
        var walletDtoResponse = response!.Value as WalletDto;
        walletDtoResponse.Should().NotBeNull();
        walletDtoResponse.Should().BeEquivalentTo(walletDtoResponseExpected, ExcludeProperties);

        _mockWalletService.Verify(x => x.GetById(It.IsAny<int>()), Times.Once());
    }
}