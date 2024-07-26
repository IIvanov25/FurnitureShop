using FurnitureShopNew;
using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using FurnitureShopNew.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    private readonly JwtSetting _jwtSettings;

    public UserService(IUserRepo userRepo, IOptions<JwtSetting> jwtSettings)
    {
        _userRepo = userRepo;
        _jwtSettings = jwtSettings.Value;
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
        // Извличане на потребител от репозитория
        var user = await _userRepo.GetUserByUsernameAsync(username);

        // Проверка на потребителските данни
        if (user == null || user.Password != password)
        {
            return null; // Връща null, ако потребителят не съществува или паролата не съвпада
        }

        // Създаване на токен
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Key); 

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email)
        }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
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
