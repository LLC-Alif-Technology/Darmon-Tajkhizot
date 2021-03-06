using System;

namespace Entities.DataTransferObjects.User
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; } 
        public string PlaceOfWork { get; set; }
        public string Profession { get; set; }
    }
}
