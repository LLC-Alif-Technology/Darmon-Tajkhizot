using Contracts.Repositories;
using Entities.DataContexts;
using Entities.DataTransferObjects.Banner;
using Entities.DataTransferObjects.Errors;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace Repositories
{
    public class EfBannerRepository:RepositoryBase<Banner>,IBannerRepository
    {
        public EfBannerRepository(DataContext context):base(context)
        {
                
        }

        public async Task<List<BannerResponse>> GetAllBannerAsync(bool trackChanges) => await FindAll(trackChanges).Select(x => new BannerResponse
        {
            Id = x.Id,
            Href = x.Href,
            ImagePath = x.ImagePath
        }).ToListAsync();

        public async Task<Banner> GetByIdAsync(Guid id, bool trackChanges) => await FindByCondition(x => x.Id.Equals(id), trackChanges).FirstOrDefaultAsync() ??
            throw new ExceptionWithStatusCode(HttpStatusCode.NotFound, "Баннер не найден");

    }
}
