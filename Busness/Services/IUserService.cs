using Buisness.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface IUserService
    {
        public UserDto CreateUser(RegisterModel model);
        public UserDto IsRegistered(LoginModel model);
        public IEnumerable<UserDto> GetAll();
        public IEnumerable<UserDto> FindByLogin(string login);
    }
}
