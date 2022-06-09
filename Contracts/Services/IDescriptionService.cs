using Entities.DataTransferObjects.Description;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IDescriptionService
    {
        Task<DescriptionResponse> GetDescription(Guid id);
        Task UpdateAsync(Guid id, UpdateDescriptionRequest request);
    }
}
