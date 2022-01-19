using Buisness.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface IDialogueParticipantService
    {
        public DialogueParticipantDto CreateDialogueParticipant(DialogueParticipantDto dialogueParticipant);
        public IEnumerable<DialogueParticipantDto> GetAll();
    }
}
