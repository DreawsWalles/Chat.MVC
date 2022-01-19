using Buisness.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface IPersonService
    {
        public PersonDto CreatePerson(PersonDto person);
        public IEnumerable<PersonDto> GetAll();
        public IEnumerable<PersonDto> FindByName(string name);
        public IEnumerable<PersonDto> FindBySername(string sername);
        public IEnumerable<PersonDto> FindByPatronymic(string patronymic);
    }
}
