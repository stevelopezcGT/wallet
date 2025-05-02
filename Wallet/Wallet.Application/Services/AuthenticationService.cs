using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Wallet.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    private readonly IConfiguration _configuration;

    public AuthenticationService(
        IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    private string GenerateJwtToken(User user)
    {
        var secretKey = _configuration["JwtBearer:SecretKey"];
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var header = new JwtHeader(signingCredentials);

        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new (JwtRegisteredClaimNames.UniqueName, user.UserName),
            new (ClaimTypes.Email, user.UserName)
        };

        var payload = new JwtPayload(
            issuer: _configuration["JwtBearer:Issuer"],
            audience: _configuration["JwtBearer:Audience"],
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.UtcNow.AddHours(24));

        var token = new JwtSecurityToken(header, payload);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        return jwtSecurityTokenHandler.WriteToken(token);
    }

    public async Task<string> Login(string userName, string password)
    {
        var user = (await _userRepository.FindAsync(d => d.UserName == userName && d.Password == password)).FirstOrDefault();
        var token = string.Empty;
        if (user != null)
        {
            token = GenerateJwtToken(user);
            return token;
        }

        return token;
    }
}