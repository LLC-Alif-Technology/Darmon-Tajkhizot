using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects.Errors;
using Entities.DataTransferObjects.User;
using Entities.DataTransferObjects.User.JWTAuthentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Entities.Helpers;
using Entities.Models;
using Entities.Enums;
namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IConfiguration _configuration;

        public UserService(IRepositoryManager repostioryManager, IConfiguration configuration)
        {
            _repositoryManager = repostioryManager;
            _configuration = configuration;
        }
        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _repositoryManager.UserRepository.GetUserByEmailAsync(request.Email, false);
            if (user == null) throw new ExceptionWithStatusCode(HttpStatusCode.NotFound, "Пользователь не найден");
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)) throw new ExceptionWithStatusCode(HttpStatusCode.Conflict, "Пароли не совпадают");
            var token = _configuration.GenerateJwtToken(user);
            var response = new AuthenticationResponse(user, token);
            return response;
        }

        public async Task<UserProfileResponse> GetUserByIdAsync(Guid id)
        {
            return await _repositoryManager.UserRepository.GetUserProfileByIdAsync(id, false);
        }

        public async Task<AuthenticationResponse> RegistrationAsync(RegistrationRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                RoleId = Roles.User,
                PhoneNumber = request.PhoneNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await _repositoryManager.UserRepository.AddUserAsync(user);
            await _repositoryManager.SaveAsync();
            var response = await AuthenticateAsync(new AuthenticationRequest()
            {
                Email = user.Email,
                Password = request.Password
            });
            return response;
        }

        public async Task UpdateUserByIdAsync(Guid userId, UpdateUserRequest request)
        {
            var user = await _repositoryManager.UserRepository.GetUserByIdAsync(userId, true);
            user.Email = request.Email ?? user.Email;
            user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
            user.FirstName = request.Name ?? user.FirstName;
            user.LastName = request.LastName ?? user.LastName;
            user.PasswordHash = string.IsNullOrEmpty(request.OldPassword)
                || string.IsNullOrEmpty(request.OldPassword) || BCrypt.Net.BCrypt.Verify(request.OldPassword, user.PasswordHash)
                ? user.PasswordHash : BCrypt.Net.BCrypt.HashPassword(request.Password);
            await _repositoryManager.SaveAsync();
        }
    }
}
