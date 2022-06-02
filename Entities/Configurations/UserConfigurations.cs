using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Entities.Enums;
namespace Entities.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                Id = Guid.NewGuid(),
                Address = "test",
                Email = "user@example.com",
                RoleId = Roles.Admin,
                FirstName = "Abubakr",
                LastName = "Nazirmadov",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Abubakr!@#$%^&*("),
                PhoneNumber = "test"
            });
        }
    }
}
