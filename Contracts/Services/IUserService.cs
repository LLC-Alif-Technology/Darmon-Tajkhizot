using Entities.DataTransferObjects.User;
using Entities.DataTransferObjects.User.JWTAuthentication;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IUserService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<AuthenticationResponse> RegistrationAsync(RegistrationRequest request);
        Task UpdateUserByIdAsync(Guid userId, UpdateUserRequest request);
        Task<UserProfileResponse> GetUserByIdAsync(Guid id);
        Task SendResetPasswordRequestAsync(string email, string backUrl);
        Task<bool> ValidateRestorationTokenAsync(string email, string token);
        Task ChangePasswordAsync(UserPasswordResetRequest request);
        Task<IEnumerable<GetAllUsersResponse>> GetAllAsync(string searchString);
    }
}
