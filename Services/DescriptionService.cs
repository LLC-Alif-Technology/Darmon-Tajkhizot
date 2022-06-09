using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects.Description;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DescriptionService:IDescriptionService
    {
        public readonly IRepositoryManager _repositoryManager;
        public DescriptionService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<DescriptionResponse> GetDescription(Guid id)
        {
            return await _repositoryManager.DescriptionRepository.GetDescription(id);
        }

        public async Task UpdateAsync(Guid id, UpdateDescriptionRequest request)
        {
            var description = await _repositoryManager.DescriptionRepository.GetByIdAsync(id, true);
            description.Name = request.Name;
            description.Text = request.Text;
            _repositoryManager.DescriptionRepository.Update(description);
            await _repositoryManager.SaveAsync();
        }
    }
}
