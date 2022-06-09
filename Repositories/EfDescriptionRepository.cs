using Contracts.Repositories;
using Entities.DataContexts;
using Entities.DataTransferObjects.Description;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EfDescriptionRepository:RepositoryBase<Description>,IDescriptionRepository
    {
        public EfDescriptionRepository(DataContext context):base(context)
        {

        }

        public async Task<Description> GetByIdAsync(Guid id, bool trackChanges) => await FindByCondition(x => x.Id.Equals(id), trackChanges).FirstOrDefaultAsync();


        public async Task<DescriptionResponse> GetDescription(Guid id) => await FindByCondition(x => x.Id.Equals(id), false).AsNoTracking().Select(d => new DescriptionResponse { 
            Id = d.Id,
            Name = d.Name,
            Text = d.Text
        }).FirstOrDefaultAsync();

    }
}
