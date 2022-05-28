using Contracts.Repositories;
using Entities.DataContexts;
using Entities.DataTransferObjects.Errors;
using Entities.DataTransferObjects.User;
using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace Repositories
{
    public class EfUserRepository : RepositoryBase<User>, IUserRepository
    {
        public EfUserRepository(DataContext context):base(context)
        {

        }
        public async Task AddUserAsync(User user) => await CreateAsync(user);

        public async Task<bool> ExistsByEmail(string email) => await FindByCondition(x => x.Email.Equals(email), false).AsNoTracking().AnyAsync();


        public async Task<List<GetAllUsersResponse>> GetAllUsersAsync(bool trackChanges) => await FindAll(trackChanges)
            .Select(x => new GetAllUsersResponse
            {
                Id = x.Id,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                RoleName = EnumHelper.GetEnumDescription(x.RoleId)
            }).ToListAsync();

        public async Task<User> GetUserByEmailAsync(string email, bool trackChanges) => await FindByCondition(x => x.Email.Equals(email), trackChanges).FirstOrDefaultAsync();


        public async Task<User> GetUserByIdAsync(Guid id, bool trackChanges) => await FindByCondition(x => x.Id.Equals(id), trackChanges).FirstOrDefaultAsync()
            ?? throw new ExceptionWithStatusCode(HttpStatusCode.NotFound, "Пользователь с таким Id не найден");

        public async Task<UserProfileResponse> GetUserProfileByIdAsync(Guid id, bool trackChanges) =>
            await FindByCondition(x => x.Id.Equals(id), trackChanges).Select(x => new UserProfileResponse
            {
                Name = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.PhoneNumber,
                Address = x.Address
            }).FirstOrDefaultAsync();


        public async Task<UserResponse> GetUserResponseByEmailAsync(string email, bool trackChanges) => await FindByCondition(x => x.Email.Equals(email), trackChanges).Select(x => new UserResponse
        {
            Id = x.Id,
            Email = x.Email,
            FirstName = x.FirstName,
            LastName = x.LastName,
            PhoneNumber = x.PhoneNumber,
            Address = x.Address
        }).SingleOrDefaultAsync() ?? throw new ExceptionWithStatusCode(HttpStatusCode.NotFound, "Пользователь с такой почтой не найден");

        public async Task<UserResponse> GetUserResponseByIdAsync(Guid id, bool trackChanges) => await FindByCondition(x => x.Id.Equals(id), trackChanges).Select(x => new UserResponse { 
            Id = x.Id,
            Email = x.Email,
            FirstName = x.FirstName,
            LastName = x.LastName,
            PhoneNumber = x.PhoneNumber,
            Address = x.Address
        }).SingleOrDefaultAsync() ??
            throw new ExceptionWithStatusCode(HttpStatusCode.NotFound, "Пользователь с таким Id не найден");

    }
}
