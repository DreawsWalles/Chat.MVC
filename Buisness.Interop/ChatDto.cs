using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Interop
{
    public class ChatDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }

        public virtual UserDto User { get; set; }
        public virtual IEnumerable<DialogueParticipantDto> Participants { get; set; }
        public virtual IEnumerable<MessageDto> Messages { get; set; }
    }
}
