using Contracts.Services;
using Entities.DataTransferObjects.User;
using Entities.DataTransferObjects.User.JWTAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darmon_Tajkhizot.Controllers
{

    public class UserController : BaseController
    {
        private readonly IUserService _userService;

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
    }
}
