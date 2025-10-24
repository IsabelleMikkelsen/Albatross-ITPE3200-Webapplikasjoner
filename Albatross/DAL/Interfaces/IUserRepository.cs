using Albatross.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Albatross.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel?> GetUserByIdAsync(int id);
        Task<UserModel?> GetUserByUsernameAsync(string username);

        Task<UserModel?> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task AddUserAsync(UserModel userModel);
        Task UpdateUserAsync(UserModel userModel);
        Task<bool> ValidateUserAsync(string username, string password);
        
    }
}