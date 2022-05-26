using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.User
{
    public class UserPasswordResetRequest
    {
        [Required]
        [EmailAddress]
        // TODO: DRY this.
        private string _email;

        [Required]
        [EmailAddress]
        public string Email
        {
            get => _email;
            set => _email = value.ToLower();
        }

        [Required]
        public string Password { get; set; }
    }
}
