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
    public class ChatRepository : AbstractRepository<Chat, Guid>, IChatRepository
    {
        public ChatRepository(Context context)
        {
            _context = context;
        }
        protected override Guid KeySelector(Chat value) => value.Id;

        protected override Chat ReadImpementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }
        protected override async Task<Chat> ReadImpementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }

        protected override void CreateImplementation(Chat value)
        {
            _context.Chats.Add(value);
        }
        protected override async Task CreateImplementationAsync(Chat value)
        {
            await _context.Chats.AddAsync(value);
        }


        protected override void UpdateImplementation(Chat entity, Chat value)
        {
            _context.Update(value);
        }
        protected override void DeleteImplementation(Chat value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.Chats.Remove(entity);
        }


        protected override IQueryable<Chat> QueryImplementation()
        {
            return _context.Chats
                .Include(chat => chat.User)
                    .ThenInclude(user => user.Person)
                .Include(chat => chat.Participants)
                    .ThenInclude(participants => participants.User)
                        .ThenInclude(user => user.Person)
                .Include(chat => chat.Messages)
                    .ThenInclude(message => message.User)
                        .ThenInclude(user => user.Person);
        }
    }
}
