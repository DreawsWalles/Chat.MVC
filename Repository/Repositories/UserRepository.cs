using Buisness.Enties;
using Buisness.Repositories.DataRepository;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : AbstractRepository<User, Guid>, IUserRepository
    {
        public UserRepository(Context context)
        {
            _context = context;
        }
        protected override Guid KeySelector(User entity) => entity.Id;


        protected override User ReadImpementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }
        protected override async Task<User> ReadImpementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }


        protected override void CreateImplementation(User value)
        {
            _context.Users.Add(value);
        }
        protected override async Task CreateImplementationAsync(User value)
        {
            await _context.Users.AddAsync(value);
        }

        protected override void UpdateImplementation(User entity, User value)
        {
            _context.Update(value);
        }

        protected override void DeleteImplementation(User value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.Users.Remove(entity);
        }

        protected override IQueryable<User> QueryImplementation()
        {
            return _context.Users
                .Include(u => u.Person);
        }
    }
}
