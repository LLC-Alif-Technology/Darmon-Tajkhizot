using Entities.DataTransferObjects.Category;
using System.Linq;

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
