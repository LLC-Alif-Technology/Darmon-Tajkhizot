using Entities.Enums;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Role
    {
        public Roles Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}
