using FurnitureShopNew.Models;

namespace FurnitureShopNew.Services
{
    public interface IUserService
    {
        Task<bool> HandleSignUpAsync(string username, string password, string firstName, string lastName, string email, string phoneNumber);
        Task<string> AuthenticateUserAsync(string username, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetCurrentUserAsync(string token);
        Task<bool> DeleteUserAsync(int id);
    }
}