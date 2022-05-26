using Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Entities.DataContexts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.DataTransferObjects.Errors;
using System.Net;
using System.Linq;

namespace Repositories
{
    public class EfRestorationTokenRepository:RepositoryBase<RestorationToken>,IRestorationTokenRepository
    {
        public EfRestorationTokenRepository(DataContext context):base(context)
        {

        }

        public async Task<RestorationToken> GetRestorationTokenByEmail(string email, bool trackChanges) => await Context.RestorationTokens.Where(x => x.Email.Equals(email)).FirstOrDefaultAsync() ??
            throw new ExceptionWithStatusCode(HttpStatusCode.NotFound, "Не найдена почта");

    }
}
