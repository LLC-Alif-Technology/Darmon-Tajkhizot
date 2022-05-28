using Entities.DataTransferObjects.Banner;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IBannerRepository:IRepositoryBase<Banner>
    {
        Task<List<BannerResponse>> GetAllBannerAsync(bool trackChanges);
        Task<Banner> GetByIdAsync(Guid id, bool trackChanges);
    }
}
