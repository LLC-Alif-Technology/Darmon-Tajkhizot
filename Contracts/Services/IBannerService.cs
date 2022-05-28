using Entities.DataTransferObjects.Banner;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IBannerService
    {
        Task<Guid> CreateAsync(CreateBannerRequest request);
        Task<Guid> DeleteByIdAsync(Guid id);
        Task<List<BannerResponse>> GetAllAsync();
        Task UpdateAsync(Guid id, UpdateBannerRequest request);
    }
}
