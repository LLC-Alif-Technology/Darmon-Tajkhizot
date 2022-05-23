using Entities.DataTransferObjects.Category;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.DataTransferObjects.Features
{
    public static class Converter
    {
        public static CategoryResponse ToCategoryResponse(this Entities.Models.Category categoryName)
        {
            return new CategoryResponse
            {
                Id = categoryName.Id,
                Name = categoryName.Name,
                IconPath = categoryName.IconPath,
                ImagePath = categoryName.ImagePath,
                SubCategories = categoryName.SubCategories.Select(x => x.ToCategoryResponse())
            };
        }
    }
}
