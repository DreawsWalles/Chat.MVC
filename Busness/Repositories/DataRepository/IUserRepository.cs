using Buisness.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Repositories.DataRepository
{
    public interface IUserRepository : IRepository<User, Guid> { }
}
