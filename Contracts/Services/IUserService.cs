using Entities.DataTransferObjects.User;
using Entities.DataTransferObjects.User.JWTAuthentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IUserService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<AuthenticationResponse> RegistrationAsync(RegistrationRequest request);
        Task UpdateUserByIdAsync(Guid userId, UpdateUserRequest request);
        Task<UserProfileResponse> GetUserByIdAsync(Guid id);
    }
}
