using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IRepositoryManager
    {
        ICategoryRepository CategoryRepository { get; }
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
