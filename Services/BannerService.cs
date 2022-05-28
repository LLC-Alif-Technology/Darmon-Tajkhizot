using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects.Banner;
using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BannerService : IBannerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IFileService _fileService;
        public BannerService(IRepositoryManager repositoryManager, IFileService fileService)
        {
            _repositoryManager = repositoryManager;
            _fileService = fileService;
        }

        public BannerService(IFileService fileService,IRepositoryManager repositoryManager)
        {
            _fileService = fileService;
            _repositoryManager = repositoryManager;
        }
        public async Task<Guid> CreateAsync(CreateBannerRequest request)
        {
            var banner = new Banner
            {
                Id = Guid.NewGuid(),
                Href = request.Href
            };

            if (request.Image != null)
                banner.ImagePath = await _fileService.AddFileAsync(request.Image, FileTypes.Image, nameof(Banner));
            await _repositoryManager.BannerRepository.CreateAsync(banner);
            await _repositoryManager.SaveAsync();
            return banner.Id;
        }

        public async Task<Guid> DeleteByIdAsync(Guid id)
        {
            var banner = await _repositoryManager.BannerRepository.GetByIdAsync(id, false);
            _repositoryManager.BannerRepository.Delete(banner);
            _fileService.DeleteFile(banner.ImagePath);
            await _repositoryManager.SaveAsync();
            return banner.Id;
        }

        public async Task<List<BannerResponse>> GetAllAsync()
        {
            return await _repositoryManager.BannerRepository.GetAllBannerAsync(false);
        }

        public async Task UpdateAsync(Guid id, UpdateBannerRequest request)
        {
            var banner = await _repositoryManager.BannerRepository.GetByIdAsync(id, false);
            banner.Href = request.Href;
            if(request.Image != null)
            {
                _fileService.DeleteFile(banner.ImagePath);
                var imagePath = await _fileService.AddFileAsync(request.Image, FileTypes.Image, nameof(Banner));
                banner.ImagePath = imagePath;
            }
            _repositoryManager.BannerRepository.Update(banner);
            await _repositoryManager.SaveAsync();
        }
    }
}
