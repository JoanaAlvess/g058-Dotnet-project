using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Users
{
    public interface IUserRepository : IRepository<User, UserId>
    {
        public Task<User> GetUserByEmail(string email);
        public Task<Role> GetUserRolebyEmail(string email);
        public Task<IList<User>> GetAllActiveAsync();
    }
}