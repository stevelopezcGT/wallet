namespace Wallet.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    // POST api/<ActosController>/login
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginDto))]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login(LoginDto authenticationDto)
    {
        var token = await _authenticationService.Login(authenticationDto.UserName, authenticationDto.Password);
        if (string.IsNullOrWhiteSpace(token))
        {
            return Unauthorized();
        }

        return Ok(new LoginSuccessDto { Token = token });
    }
}