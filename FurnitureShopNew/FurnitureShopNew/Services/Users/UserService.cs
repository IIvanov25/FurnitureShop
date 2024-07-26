using FurnitureShopNew.Models;
using FurnitureShopNew.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class UserService : IUserService
{
    private readonly ShopDbContext _context;
    private readonly IUserRepo _userRepo;
    private readonly IConfiguration _configuration;

    public UserService(ShopDbContext context, IConfiguration configuration, IUserRepo userRepo)
    {
        _context = context;
        _configuration = configuration;
        _userRepo = userRepo;
    }

    public async Task<bool> HandleSignUpAsync(string username, string firstName, string lastName, string email, string phoneNumber, string password)
    {
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username || u.Email == email);

        if (existingUser != null)
        {
            return false;
        }

        var user = new User
        {
            Username = username,
            Password = password,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Role = UserType.Client
        };

        await _userRepo.AddUserAsync(user);
        _context.SaveChanges();
        return true;
    }

    public async Task<bool> AuthenticateUserAsync(string username, string password)
    {
        var user = await _userRepo.GetUserByUsernameAsync(username);

        if (user == null || user.Password != password)
        {
            return false;
        }

        return true;
    }


    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        try
        {
            return await _context.Users.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to retrieve users from the database.", ex);
        }
    }

    public async Task<User> GetCurrentUserAsync(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtToken = tokenHandler.ReadJwtToken(token);

            var username = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to retrieve the current user.", ex);
        }
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        try
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to delete user.", ex);
        }
    }
}
