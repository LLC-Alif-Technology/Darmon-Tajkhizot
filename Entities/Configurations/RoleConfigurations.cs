using Entities.Enums;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            foreach (var roles in (Roles[])Enum.GetValues(typeof(Roles)))
            {
                builder.HasData(new Role
                {
                    Id = roles,
                    Name = EnumHelper.GetEnumDescription(roles)
                });
            }
        }
    }
}
