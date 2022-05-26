using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class RestorationToken
    {
        private string _email;

        public RestorationToken(string email, string token)
        {
            Email = email;
            Token = token;
            CreationDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Required]
        public string Email
        {
            get => _email;
            set => _email = value.ToLower();
        }

        public string Token { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsVerified { get; set; }
    }
}

