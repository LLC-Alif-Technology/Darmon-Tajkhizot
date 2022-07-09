using AutoMapper;
using Entities.DataTransferObjects.Banner;
using Entities.DataTransferObjects.Category;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darmon_Tajkhizot.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Banner, BannerResponse>();
            CreateMap<Category, CategoryResponse>();
        }
    }
}
