using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.User
{
    public class UserProfileResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
