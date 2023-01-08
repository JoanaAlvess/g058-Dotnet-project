using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Users;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace DDDSample1.Infrastructure.Users
{
    public class UserRepository : BaseRepository<User, UserId>, IUserRepository
    {
        private readonly DDDSample1DbContext _context;
        private readonly DbSet<User> _users;
        public UserRepository(DDDSample1DbContext context) : base(context.Users)
        {
            _context = context;
            _users = context.Users;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await this._users
                .Where(u => u._Email.email.Equals(email)
                ).FirstAsync();

            return user;
        }

        public async Task<Role> GetUserRolebyEmail(string email)
        {
            var user = await this._users
                .Where(u => u._Email.email.Equals(email)
                ).FirstAsync();

            return user._Role;
        }

        public async Task<IList<User>> GetAllActiveAsync()
        {    
            return await this._users.Where(u => u.Active.Equals(true)).ToListAsync();
        }
    }
}