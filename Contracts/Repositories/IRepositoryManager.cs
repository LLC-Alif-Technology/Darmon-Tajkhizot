using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IRepositoryManager
    {
        ICategoryRepository CategoryRepository { get; }
        IUserRepository UserRepository { get; }
        IRestorationTokenRepository RestorationTokenRepository { get; }
        Task SaveAsync();
    }
}
