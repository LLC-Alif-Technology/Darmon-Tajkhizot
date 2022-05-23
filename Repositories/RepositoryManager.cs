using Contracts.Repositories;
using Entities.DataContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private DataContext _context;
        public RepositoryManager(DataContext context)
        {
            _context = context;
        }
        public ICategoryRepository _categoryRepository;
        public IUserRepository _userRepository;

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new EfCategoryRepository(_context);
        public IUserRepository UserRepository => _userRepository ??= new EfUserRepository(_context);
            

    }
}
