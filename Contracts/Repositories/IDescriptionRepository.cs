using Entities.DataTransferObjects.Description;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IDescriptionRepository:IRepositoryBase<Description>
    {
        Task<DescriptionResponse> GetDescription(Guid id);
        Task<Description> GetByIdAsync(Guid id, bool trackChanges);
        Task<IEnumerable<DescriptionResponse>> GetAllAsync(bool trackChanges);
    }
}
