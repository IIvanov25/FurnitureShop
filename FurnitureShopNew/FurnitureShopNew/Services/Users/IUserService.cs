using System.Threading.Tasks;

namespace FurnitureShopNew.Services
{
    public interface IUserService
    {
        //Task<User> FindUserByEmailAsync(string email);
        //Task<bool> IsLoginInfoValidAsync(string email, string password);
        Task<bool> HandleSignUpAsync(string username, string firstName, string lastName, string email, string phoneNumber, string password);
        Task<bool> HandleUserDeleteAsync(string email, string token);
        //Task<bool> ChangePasswordAsync(string email, string currentPassword, string newPassword);
        //string GenerateJwtToken(User user);
        Task <bool> AuthenticateUser (string username, string password);
    }
}
