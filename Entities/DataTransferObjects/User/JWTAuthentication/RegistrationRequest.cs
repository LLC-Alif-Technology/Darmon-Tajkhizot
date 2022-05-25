using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.User.JWTAuthentication
{
    public class RegistrationRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
