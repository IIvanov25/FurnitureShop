using FurnitureShopNew.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureShopNew.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly ShopDbContext _context;

        public UserRepo(ShopDbContext context)
        {
            _context = context;
        }
        public async Task AddUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to add user", ex);
            }
        }

        public async Task DeleteUserEmailAsync(string email)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to delete user", ex);
            }
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            try
            {
                return await _context.Users.FirstAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to find user", ex);
            }
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}