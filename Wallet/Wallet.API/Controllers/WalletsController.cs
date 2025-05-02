namespace Wallet.Api.Controllers;

/// <summary>
/// Controller for managing wallet-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class WalletsController : ControllerBase
{
    private IWalletService _walletService;

    private IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="WalletsController"/> class.
    /// </summary>
    /// <param name="walletService">The wallet service to handle business logic.</param>
    /// <param name="mapper">The mapper for object transformations.</param>
    public WalletsController(IWalletService walletService, IMapper mapper)
    {
        _walletService = walletService;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all wallets.
    /// </summary>
    /// <returns>A list of wallets.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WalletDto>))]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        List<Domain.Entities.Wallet> wallets = (await _walletService.GetAll() as List<Domain.Entities.Wallet>)!;
        return Ok(_mapper.Map<List<WalletDto>>(wallets));
    }

    /// <summary>
    /// Retrieves a wallet by its ID.
    /// </summary>
    /// <param name="id">The ID of the wallet.</param>
    /// <returns>The wallet with the specified ID.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WalletDto))]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(int id)
    {
        var wallet = await _walletService.GetById(id);
        return Ok(_mapper.Map<WalletDto>(wallet));
    }

    /// <summary>
    /// Creates a new wallet.
    /// </summary>
    /// <param name="walletDto">The wallet data to create.</param>
    /// <returns>The created wallet.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WalletDto))]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CreateWalletDto walletDto)
    {
        var wallet = await _walletService.Create(_mapper.Map<CreateWalletDto, Domain.Entities.Wallet>(walletDto)!);
        var resourceUrl = $"{Request.Path}/{wallet.Id}";
        return Created(resourceUrl, _mapper.Map<WalletDto>(wallet));
    }

    /// <summary>
    /// Updates an existing wallet.
    /// </summary>
    /// <param name="walletDto">The wallet data to update.</param>
    /// <returns>The updated wallet.</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WalletDto))]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put([FromBody] UpdateWalletDto walletDto)
    {
        var wallet = await _walletService.Edit(_mapper.Map<Domain.Entities.Wallet>(walletDto)!);
        return Ok(_mapper.Map<WalletDto>(wallet));
    }

    /// <summary>
    /// Deletes a wallet by its ID.
    /// </summary>
    /// <param name="id">The ID of the wallet to delete.</param>
    /// <returns>No content.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _walletService.Delete(id);
        return NoContent();
    }

    /// <summary>
    /// Transfers an amount between wallets.
    /// </summary>
    /// <param name="walletId">The ID of the wallet to transfer from.</param>
    /// <param name="transferDto">The transfer details.</param>
    /// <returns>The updated wallet after the transfer.</returns>
    [HttpPost]
    [Route("{walletId}/transfer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WalletDto))]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Transfer(int walletId, [FromBody] TransactionRequestDto transferDto)
    {
        var wallet = await _walletService.Transaction(walletId, transferDto);
        return Ok(_mapper.Map<WalletDto>(wallet));
    }

    [HttpGet]
    [Route("{walletId}/history")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WalletDto))]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> History(int walletId)
    {
        var wallet = await _walletService.GetHistoryById(walletId);
        return Ok(_mapper.Map<WalletDto>(wallet));
    }
}