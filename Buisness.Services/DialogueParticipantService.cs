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
    public class DialogueParticipantService : IDialogueParticipantService
    {
        private readonly IDialogueParticipantRepository _dialogueParticipantRepository;
        private readonly IMapper _mapper;

        public DialogueParticipantService(IDialogueParticipantRepository dialogueParticipantRepository, IMapper mapper)
        {
            _dialogueParticipantRepository = dialogueParticipantRepository;
            _mapper = mapper;
        }

        public DialogueParticipantDto CreateDialogueParticipant(DialogueParticipantDto dialogueParticipant)
        {
            var entity = _mapper.Map<DialogueParticipant>(dialogueParticipant);
            _dialogueParticipantRepository.CreateOrUpdate(entity);
            return _mapper.Map<DialogueParticipantDto>(entity);
        }

        public IEnumerable<DialogueParticipantDto> GetAll()
        {
            var tmp = _dialogueParticipantRepository.Query();
            return _mapper.Map<IEnumerable<DialogueParticipant>, IEnumerable<DialogueParticipantDto>>(tmp);
        }
    }
}
