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
    public class PersonRepository : AbstractRepository<Person, Guid>, IPersonRepository
    {
        public PersonRepository(Context context)
        {
            _context = context;
        }

        protected override Guid KeySelector(Person entity) => entity.Id;

        protected override Person ReadImpementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }
        protected override async Task<Person> ReadImpementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }

        protected override void CreateImplementation(Person value)
        {
            _context.People.Add(value);
        }
        protected override async Task CreateImplementationAsync(Person value)
        {
            await _context.People.AddAsync(value);
        }

        protected override void UpdateImplementation(Person entity, Person value)
        {
            _context.Update(value);
        }

        protected override void DeleteImplementation(Person value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.People.Remove(entity);
        }

        protected override IQueryable<Person> QueryImplementation()
        {
            return _context.People;
        }
    }
}
