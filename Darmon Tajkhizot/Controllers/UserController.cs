using Contracts.Services;
using Entities.DataTransferObjects.User;
using Entities.DataTransferObjects.User.JWTAuthentication;
using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Darmon_Tajkhizot.Controllers
{

    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/api/registration")]
        public async Task<IActionResult> Registration(RegistrationRequest request)
        {
            return Ok(await _userService.RegistrationAsync(request));
        }

        [HttpPost("/api/login")]
        public async Task<IActionResult> Authentication(AuthenticationRequest request)
        {
            return Ok(await _userService.AuthenticateAsync(request));
        }

        [HttpPut("profile")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Update(UpdateUserRequest user)
        {
            var currentUserId = GetCurrentUserId();
            await _userService.UpdateUserByIdAsync(currentUserId, user);
            return Ok();
        }

        [HttpGet("profile")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetUserById()
        {
            var currentUserId = GetCurrentUserId();
            return Ok(await _userService.GetUserByIdAsync(currentUserId));
        }

        [HttpGet("users")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = nameof(Roles.Admin) + ", "+ nameof(Roles.Manager))]
        public async Task<IActionResult> GetUsers(string searchString)
        {
            return Ok(await _userService.GetAllAsync(searchString));
        }

        /// <summary>
        ///     Send(request) a password restoration token to the given email.
        /// </summary>
        /// <response code="404">If user not found</response>
        [AllowAnonymous]
        [HttpPost("send-reset-request")]
        public async Task<IActionResult> SendResetPasswordRequestAsync(string email, string backUrl)
        {
            await _userService.SendResetPasswordRequestAsync(email, backUrl);
            return Ok();
        }

        /// <summary>
        ///     Validate that the token is indeed, same with the sent (email)
        ///     First need to request the token.
        /// </summary>
        /// <response code="404">If user or token not found</response>
        /// <response code="401">Token is invalid</response>
        [AllowAnonymous]
        [HttpPost("validate-reset-request")]
        public async Task<ActionResult> ValidateResetRequestAsync(string email, string token)
        {
            return Ok(await _userService.ValidateRestorationTokenAsync(email, token));
        }

        /// <summary>
        ///     Change user password.
        ///     First need to validate restoration token
        /// </summary>
        /// <response code="404">User with the given email not found</response>
        /// <response code="401">Restoration request not found (was not requested or used)</response>
        [AllowAnonymous]
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangeUserPasswordAsync(UserPasswordResetRequest request)
        {
            await _userService.ChangePasswordAsync(request);
            return Ok();
        }
    }
}
