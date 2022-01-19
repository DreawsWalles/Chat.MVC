using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Enties
{
    public class DialogueParticipant
    {
        public Guid Id { get; set; }
        public virtual IEnumerable<Chat> Chats { get; set; }
        public virtual User User { get; set; }
    }
}
