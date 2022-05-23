using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configurations
{
    public class CategoryConfigurations:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.SubCategories)
               .WithOne(x => x.ParentCategory)
               .IsRequired(false);
            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
