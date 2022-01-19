using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Interop
{
    public class DialogueParticipantDto
    {
        public Guid Id { get; set; }
        public virtual IEnumerable<ChatDto> Chats { get; set; }
        public virtual UserDto User { get; set; }
    }
}
