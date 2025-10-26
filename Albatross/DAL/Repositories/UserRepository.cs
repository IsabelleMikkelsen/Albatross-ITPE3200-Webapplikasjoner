//using Albatross.Data;
using Albatross.Models;
using Albatross.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Albatross.DAL.Repositories
{
    public class UserRepository : IUserRepository

    {
        private readonly ItemDbContext _context;

        public UserRepository(ItemDbContext context) => _context = context;

        public async Task<UserModel?> GetUserByIdAsync(int id)
        {
            return await _context.UserModels.FindAsync(id)!;
        }
        
        public async Task<UserModel?> GetUserByUsernameAsync(string username) =>
            await _context.UserModels.FirstOrDefaultAsync(u => u.Username == username);

        public async Task<UserModel?> GetUserByEmailAsync(string email) =>
            await _context.UserModels.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync() =>
            await _context.UserModels.ToListAsync();

        public async Task AddUserAsync(UserModel userModel)
        {
            userModel.PasswordHash = HashPassword(userModel.PasswordHash);
            _context.UserModels.Add(userModel);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateUserAsync(UserModel userModel)
        {
            _context.UserModels.Update(userModel);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            var user = await GetUserByUsernameAsync(username);
            if (user == null) return false;

            var hashedInput = HashPassword(password);
            return user.PasswordHash == hashedInput;
        }
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
       
    }
}
        
    