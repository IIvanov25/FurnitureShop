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
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}