using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IRestorationTokenRepository:IRepositoryBase<RestorationToken>
    {
        Task<RestorationToken> GetRestorationTokenByEmail(string email, bool trackChanges);
    }
}
