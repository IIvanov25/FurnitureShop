namespace FurnitureShopNew.Models
{
    public interface IUserRepo
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}