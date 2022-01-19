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
    public class MessageRepository : AbstractRepository<Message, Guid>, IMessageRepository
    {
        public MessageRepository(Context context)
        {
            _context = context;
        }

        protected override void CreateImplementation(Message value)
        {
            _context.Messages.Add(value);
        }

        protected override async Task CreateImplementationAsync(Message value)
        {
            await _context.Messages.AddAsync(value);
        }

        protected override void DeleteImplementation(Message value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.Messages.Remove(entity);
        }

        protected override Guid KeySelector(Message value) => value.Id;


        protected override Message ReadImpementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }

        protected override async Task<Message> ReadImpementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }

        protected override void UpdateImplementation(Message entity, Message value)
        {
            _context.Update(value);
        }

        protected override IQueryable<Message> QueryImplementation()
        {
            return _context.Messages
                .Include(message => message.User)
                .Include(message => message.Chat);
        }
    }
}
