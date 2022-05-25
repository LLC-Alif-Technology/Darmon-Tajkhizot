using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Darmon_Tajkhizot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected Guid GetCurrentUserId()
        {
            return HttpContext.User.Identity is not ClaimsIdentity identity ? Guid.Empty : Guid.Parse(identity.FindFirst("id")?.Value ?? string.Empty);
        }
    }
}
