using Entities.Helpers;
using System;

namespace Entities.DataTransferObjects.User.JWTAuthentication
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(Entities.Models.User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            FirstName = user.FirstName;
            LastName = user.LastName;
            RoleName = EnumHelper.GetEnumDescription(user.RoleId);
            Token = token;
        }
    }
}
