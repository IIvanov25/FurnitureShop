using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using FurnitureShopNew.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepo userRepo, IConfiguration configuration)
    {
        _userRepo = userRepo;
        _configuration = configuration;
    }

    public async Task<bool> HandleSignUpAsync(string username, string firstName, string lastName, string email, string phoneNumber, string password)
    {
        
        var user = new User
        {
            Username = username,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Password = password, 
            Role = UserType.Client
        };

        await _userRepo.AddUserAsync(user);
        return true;
    }

    public async Task<string> AuthenticateUserAsync(string username, string password)
    {
        var user = await _userRepo.GetUserByUsernameAsync(username);

        if (user == null || user.Password != password)
        {
            return null; 
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(s: _configuration["Jwt:Secret"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"])),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepo.GetAllUsersAsync();
    }

    public async Task<User> GetCurrentUserAsync(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        var username = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

        if (string.IsNullOrEmpty(username))
        {
            return null; 
        }

        return await _userRepo.GetUserByUsernameAsync(username);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _userRepo.GetUserByIdAsync(id);

        if (user == null)
        {
            return false; 
        }

        await _userRepo.DeleteUserAsync(user);
        return true;
    }
}
