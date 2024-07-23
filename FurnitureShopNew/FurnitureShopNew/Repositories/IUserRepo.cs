namespace FurnitureShopNew.Models
{
    public interface IUserRepo
    {
        Task AddUserAsync(User user);
        Task DeleteUserEmailAsync(string email);
        Task<User> FindByEmailAsync(string email);

    }
}