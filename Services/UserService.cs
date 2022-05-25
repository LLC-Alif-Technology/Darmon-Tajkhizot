using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects.Errors;
using Entities.DataTransferObjects.User;
using Entities.DataTransferObjects.User.JWTAuthentication;
using Microsoft.Extensions.Configuration;
using System;
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
        private readonly IEmailService _emailService;

        public UserService(IRepositoryManager repostioryManager, IConfiguration configuration, IEmailService emailService)
        {
            _repositoryManager = repostioryManager;
            _configuration = configuration;
            _emailService = emailService;
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

        // Save info about the pass restoration process (when requesting)
        private async Task SavePasswordRestorationTokenAsync(string email, string token)
        {
            // If already exists delete it
            var dbToken = await GetRestorationTokenByEmailAsync(email);
            if (dbToken != null)
                _db.RestorationTokens.Remove(dbToken);

            await _db.RestorationTokens.AddAsync(new RestorationToken(email, token));
            await _db.SaveChangesAsync();
        }

        public async Task SendResetPasswordRequestAsync(string email, string backUrl)
        {
            // Get a random (unique) string
            var token = JwtHelper.GetRandomString();

            // Send the email
            await _emailService.SendPasswordResetMailAsync(email, token, backUrl);
            // Save to db
            await SavePasswordRestorationTokenAsync(email, token);
        }

        private async Task<RestorationToken> GetRestorationTokenByEmailAsync(string email)
        {
            return await _db.RestorationTokens.SingleOrDefaultAsync(x => x.Email == email);
        }

        /// <summary>
        ///     Change password of the given user
        ///     the new password is given with the request (in the place of the actual password)
        ///     this is secured(verified) by the GetPasswordRestorationToken method and token.IsVerified
        /// </summary>
        public async Task<UserInfo> ChangePasswordAsync(UserPasswordResetDto request)
        {
            var user = await FindByEmailAsync(request.Email);

            var token = await GetPasswordRestorationTokenAsync(request.Email);

            if (!token.IsVerified)
                throw new UnauthorizedResponse(ErrorMessages.TokenNotVerified);

            // Remove the restoration token
            _db.RestorationTokens.Remove(token);

            // Change the password and save the changes.
            user.AssignPassword(request.Password);
            await _db.SaveChangesAsync();

            return user.ToUserInfo();
        }


        // Get the restoration token that, was saved (when requesting restoration)
        private async Task<RestorationToken> GetPasswordRestorationTokenAsync(string email)
        {
            var token = await GetRestorationTokenByEmailAsync(email);

            return token;
        }

        // This gets called when the user provides the correct token
        // (that was sent by email)
        public async Task<bool> ValidateRestorationTokenAsync(string email, string token)
        {
            // Get the stored token.
            var storedToken = await GetPasswordRestorationTokenAsync(email);

            storedToken.IsVerified = true;
            await _db.SaveChangesAsync();

            return true;
        }

    }
}
