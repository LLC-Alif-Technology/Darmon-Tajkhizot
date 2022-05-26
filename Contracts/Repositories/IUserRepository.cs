using Entities.DataTransferObjects.User;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task AddUserAsync(User user);
        Task<List<GetAllUsersResponse>> GetAllUsersAsync(bool trackChanges);
        Task<User> GetUserByIdAsync(Guid id, bool trackChanges);
        Task<UserResponse> GetUserResponseByIdAsync(Guid id, bool trackChanges);
        Task<User> GetUserByEmailAsync(string email, bool trackChanges);
        Task<UserResponse> GetUserResponseByEmailAsync(string email, bool trackChanges);
        Task<UserProfileResponse> GetUserProfileByIdAsync(Guid id, bool trackChanges);
        Task<bool> ExistsByEmail(string email);
    }
}
