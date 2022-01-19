using AutoMapper;
using Buisness.Enties;
using Buisness.Interop;
using Buisness.Repositories.DataRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        public UserDto CreateUser(RegisterModel model)
        {
            UserDto user = new UserDto()
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Person = new PersonDto()
                { 
                    Name = model.Name,
                    Sername = model.Sername,
                    Patronymic = model.Patronymic
                },
                Avatar = Convert.ToBase64String(File.ReadAllBytes("C:/Users/spits/Desktop/project/Chat/Chat.MVC/wwwroot/image/AvatarProfile.png"))
            };
            var entity = _mapper.Map<User>(user);
            entity.PasswordHash = new PasswordHasher<User>().HashPassword(new User(), model.Password);
            _userRepository.CreateOrUpdate(entity);
            return _mapper.Map<UserDto>(entity);
        }

        public IEnumerable<UserDto> FindByLogin(string login)
        {
            var users = _userRepository.Query()
                .Where(element => element.UserName.Contains(login, System.StringComparison.InvariantCultureIgnoreCase));
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _userRepository.Query();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public UserDto IsRegistered(LoginModel model)
        {
            var users = _userRepository.Query()
                .Where(element => element.UserName.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase));
            if (users.Any())
            {
                var tmp = new PasswordHasher<User>().VerifyHashedPassword(new User(), users.ToList()[0].PasswordHash, model.Password);
                return tmp == PasswordVerificationResult.Success ? _mapper.Map<UserDto>(users.ToList()[0]) : null;
            }
            users = _userRepository.Query()
                .Where(element => element.PhoneNumber.Contains(model.Login, System.StringComparison.InvariantCultureIgnoreCase));
            if (users.Any())
            {
                var tmp = new PasswordHasher<User>().VerifyHashedPassword(new User(), users.ToList()[0].PasswordHash, model.Password);
                return tmp == PasswordVerificationResult.Success ? _mapper.Map<UserDto>(users.ToList()[0]) : null;
            }
            return null;
        }
    }
}
