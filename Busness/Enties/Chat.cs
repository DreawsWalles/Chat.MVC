using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Enties
{
    public class Chat
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }    
        public string Avatar { get; set; }

        public virtual User User { get; set; }
        public virtual IEnumerable<DialogueParticipant> Participants { get; set; }
        public virtual IEnumerable<Message> Messages { get; set; }
    }
}
