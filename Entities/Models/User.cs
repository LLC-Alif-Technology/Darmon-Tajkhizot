using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PassowrdHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Roles RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
