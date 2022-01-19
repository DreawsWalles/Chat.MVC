using AutoMapper;
using Buisness.Enties;
using Buisness.Interop;
using Buisness.Repositories.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            _personRepository = repository;
            _mapper = mapper;
        }

        public PersonDto CreatePerson(PersonDto person)
        {
            var entity = _mapper.Map<Person>(person);
            _personRepository.CreateOrUpdate(entity);
            return _mapper.Map<PersonDto>(entity);
        }

        public IEnumerable<PersonDto> FindByName(string name)
        {
            var people = _personRepository.Query()
                .Where(element => element.Name.Contains(name, System.StringComparison.InvariantCultureIgnoreCase));
            return _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDto>>(people);
        }

        public IEnumerable<PersonDto> FindByPatronymic(string patronymic)
        {
            var people = _personRepository.Query()
                .Where(element => element.Patronymic.Contains(patronymic, System.StringComparison.InvariantCultureIgnoreCase));
            return _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDto>>(people);
        }

        public IEnumerable<PersonDto> FindBySername(string sername)
        {
            var people = _personRepository.Query()
                .Where(element => element.Sername.Contains(sername, System.StringComparison.InvariantCultureIgnoreCase));
            return _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDto>>(people);
        }

        public IEnumerable<PersonDto> GetAll()
        {
            var people = _personRepository.Query();
            return _mapper.Map<List<Person>, IEnumerable<PersonDto>>(people);
        }
    }
}
