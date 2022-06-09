using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.User
{
    public class UpdateUserRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }
        public string PlaceOfWork { get; set; }
        public string Profession { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
    }
}
