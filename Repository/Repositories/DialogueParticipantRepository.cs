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
    public class DialogueParticipantRepository : AbstractRepository<DialogueParticipant, Guid>, IDialogueParticipantRepository
    {
        public DialogueParticipantRepository(Context context)
        {
            _context = context;
        }

        protected override Guid KeySelector(DialogueParticipant value) => value.Id;


        protected override DialogueParticipant ReadImpementation(Guid key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }
        protected override async Task<DialogueParticipant> ReadImpementationAsync(Guid key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }

        protected override IQueryable<DialogueParticipant> QueryImplementation()
        {
            return _context.Participants
                .Include(Participants => Participants.User)
                    .ThenInclude(user => user.Person)
                .Include(Participants => Participants.Chats);
        }

        protected override void CreateImplementation(DialogueParticipant value)
        {
            _context.Participants.Add(value);
        }

        protected override async Task CreateImplementationAsync(DialogueParticipant value)
        {
            await _context.Participants.AddAsync(value);
        }

        protected override void UpdateImplementation(DialogueParticipant entity, DialogueParticipant value)
        {
            _context.Update(value);
        }

        protected override void DeleteImplementation(DialogueParticipant value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.Participants.Remove(entity);
        }
    }
}
